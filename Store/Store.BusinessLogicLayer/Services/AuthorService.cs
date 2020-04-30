using AutoMapper;
using Store.BusinessLogicLayer.Interfaces;
using Store.BusinessLogicLayer.Models.Author;
using Store.DataAccessLayer.Entities;
using Store.DataAccessLayer.Repositories.Interfaces;
using Store.Shared.Common;
using Store.Shared.Constants;
using Store.Shared.Enums;
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

        public AuthorService(IAuthorRepository<Author> authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task CreateAuthorAsync(AuthorModel model)
        {

            Author author = await _authorRepository.GetOneAsync(model.Name);
            if (!(author is null))
            {
                throw new UserException(Constant.Errors.AUTHOR_ALREADY_EXISTS, Enums.ErrorCode.BadRequest);
            }

            await _authorRepository.CreateAsync(_mapper.Map<Author>(model));
        }

        public async Task<IEnumerable<AuthorModel>> GetAuthorsAsync()
        {
            IEnumerable<AuthorModel> authors = _mapper.Map<IEnumerable<AuthorModel>>(await _authorRepository.GetAllAsync());
            if (!authors.Any())
            {
                throw new UserException(Constant.Errors.AUTHOR_NOT_FOUND, Enums.ErrorCode.BadRequest);
            }

            return authors;
        }

        public async Task<AuthorModel> GetOneAuthorAsync(Guid id)
        {
            Author author = await _authorRepository.GetOneAsync(id);
            if (author is null)
            {
                throw new UserException(Constant.Errors.AUTHOR_NOT_FOUND, Enums.ErrorCode.BadRequest);
            }
            return _mapper.Map<AuthorModel>(author);
        }

        public async Task<AuthorModel> GetOneAuthorAsync(AuthorModel model)
        {
            Author author = await _authorRepository.GetOneAsync(model.Name);
            if (author is null)
            {
                throw new UserException(Constant.Errors.AUTHOR_NOT_FOUND, Enums.ErrorCode.BadRequest);
            }
            return _mapper.Map<AuthorModel>(author);
        }

        public async Task RemoveAuthorAsync(AuthorModel model)
        {
            Author author = await _authorRepository.GetOneAsync(model.Name);
            if (author is null)
            {
                throw new UserException(Constant.Errors.AUTHOR_NOT_FOUND, Enums.ErrorCode.BadRequest);
            }
            await _authorRepository.RemoveOneAsync(author);
        }

        public async Task UpdateAuthorAsync(AuthorModel model)
        {
            Author author = await _authorRepository.GetOneAsync(model.Id);
            if (author is null)
            {
                throw new UserException(Constant.Errors.AUTHOR_NOT_FOUND, Enums.ErrorCode.BadRequest);
            }

            await _authorRepository.RemoveOneAsync(author);

            await _authorRepository.CreateAsync(_mapper.Map<Author>(model));
        }
    }
}
