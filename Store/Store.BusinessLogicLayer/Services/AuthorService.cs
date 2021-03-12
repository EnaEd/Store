using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Store.BusinessLogicLayer.Interfaces;
using Store.BusinessLogicLayer.Models.Author;
using Store.BusinessLogicLayer.Models.Base;
using Store.DataAccessLayer.Entities;
using Store.DataAccessLayer.Models;
using Store.DataAccessLayer.Repositories.Interfaces;
using Store.Shared.Common;
using Store.Shared.Constants;
using Store.Shared.Enums;
using Store.Shared.Providers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.BusinessLogicLayer.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository<Author> _authorRepository;
        private readonly IMapper _mapper;
        private readonly IValidationProvider _validationProvider;

        public AuthorService(IAuthorRepository<Author> authorRepository, IMapper mapper, IValidationProvider validationProvider)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
            _validationProvider = validationProvider;
        }

        public async Task CreateAuthorAsync(AuthorModel model)
        {
            if (!_validationProvider.TryValidate(model, out List<string> errors))
            {
                throw new UserException(errors, Enums.ErrorCode.BadRequest);
            }

            Author author = await _authorRepository.GetOneAsync(model.Name);
            if (author is not null)
            {
                throw new UserException(Constant.Errors.ENTITY_ALREADY_EXISTS, Enums.ErrorCode.BadRequest);
            }

            var mappedModel = _mapper.Map<Author>(model);

            await _authorRepository.CreateAsync(mappedModel);
        }

        public async Task<PaginationModel<IEnumerable<AuthorModel>>> GetAuthorsAsync(AuthorFilterModel model)
        {

            var mappedDTO = _mapper.Map<AuthorFilterDTO>(model);

            var entities = await _authorRepository.GetAllFiltered(mappedDTO).ToListAsync();
            if (!entities.Any())
            {
                throw new UserException(Constant.Errors.ENTITY_NOT_FOUND, Enums.ErrorCode.BadRequest);
            }

            var mappedAuthorModel = _mapper.Map<IEnumerable<AuthorModel>>(entities);
            int totalCount = await _authorRepository.GetCountAsync(mappedDTO);

            var pageModel = new PaginationModel<IEnumerable<AuthorModel>>();
            pageModel.Data = mappedAuthorModel;
            pageModel.Count = (int)Math.Ceiling((double)totalCount / model.PageSize);
            pageModel.HasNext = model.PageSize * model.PageNumber < totalCount;
            pageModel.HasPrevious = model.PageNumber - Constant.Common.DEFAULT_PAGE_OFFSET > default(int);
            pageModel.PageNumber = model.PageNumber;
            pageModel.PageSize = model.PageSize;

            return pageModel;
        }

        public async Task<AuthorModel> GetOneAuthorAsync(AuthorModel model)
        {
            Author author = await _authorRepository.GetOneAsync(model.Id);
            if (author is null)
            {
                throw new UserException(Constant.Errors.ENTITY_NOT_FOUND, Enums.ErrorCode.BadRequest);
            }
            var result = _mapper.Map<AuthorModel>(author);
            return result;
        }

        public async Task RemoveAuthorAsync(AuthorModel model)
        {
            if (!_validationProvider.TryValidate(model, out List<string> errors))
            {
                throw new UserException(errors, Enums.ErrorCode.BadRequest);
            }

            Author author = await _authorRepository.GetOneAsync(model.Name);
            if (author is null)
            {
                throw new UserException(Constant.Errors.ENTITY_NOT_FOUND, Enums.ErrorCode.BadRequest);
            }
            await _authorRepository.RemoveOneAsync(author);
        }

        public async Task UpdateAuthorAsync(AuthorModel model)
        {
            if (!_validationProvider.TryValidate(model, out List<string> errors))
            {
                throw new UserException(errors, Enums.ErrorCode.BadRequest);
            }

            Author author = await _authorRepository.GetOneAsync(model.Id);
            if (author is null)
            {
                throw new UserException(Constant.Errors.ENTITY_NOT_FOUND, Enums.ErrorCode.BadRequest);
            }

            author = _mapper.Map<Author>(model);
            await _authorRepository.UpdateAsync(author);
        }
    }
}
