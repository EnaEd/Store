using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Store.BusinessLogicLayer.Interfaces;
using Store.BusinessLogicLayer.Models.Author;
using Store.BusinessLogicLayer.Models.Base;
using Store.BusinessLogicLayer.Models.PrintingEdition;
using Store.DataAccessLayer.Entities;
using Store.DataAccessLayer.Models;
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
    public class PrintingEditionService : IPrintingEditionService
    {
        private readonly IAuthorService _authorService;
        private readonly IPrintingEditionRepository<PrintingEdition> _printingEditionRepository;
        private readonly IMapper _mapper;

        public PrintingEditionService(IPrintingEditionRepository<PrintingEdition> printingEditionRepository, IMapper mapper,
            IAuthorService authorService)
        {
            _printingEditionRepository = printingEditionRepository;
            _mapper = mapper;
            _authorService = authorService;
        }
        public async Task UpdatePrintingEditionAsync(PrintingEditionProfileModel printingEditionProfile)
        {
            if (printingEditionProfile is null)
            {
                throw new UserException(Constant.Errors.UPDATE_EDITION_FAIL, Enums.ErrorCode.BadRequest);
            }
            AuthorModel author = await _authorService.GetOneAuthorAsync(new AuthorModel { Name = printingEditionProfile.Author });
            if (author is null)
            {
                throw new UserException(Constant.Errors.ENTITY_NOT_FOUND, Enums.ErrorCode.BadRequest);
            }
            PrintingEdition edition = await _printingEditionRepository.GetOneAsync(printingEditionProfile.Id);

            await _printingEditionRepository.RemoveOneAsync(edition);
            await _printingEditionRepository.CreateAsync(_mapper.Map<PrintingEdition>(printingEditionProfile));
        }
        public async Task DeletePrintingEditionAsync(PrintingEditionProfileModel printingEditionProfile)
        {
            if (printingEditionProfile is null)
            {
                throw new UserException(Constant.Errors.DELETE_EDITION_FAIL, Enums.ErrorCode.BadRequest);
            }

            PrintingEdition edition = await _printingEditionRepository.GetOneAsync(printingEditionProfile.Id);
            if (edition is null)
            {
                throw new UserException(Constant.Errors.DELETE_EDITION_FAIL, Enums.ErrorCode.BadRequest);
            }

            await _printingEditionRepository.RemoveOneAsync(edition);
        }
        public async Task CreatePrintingEditionAsync(PrintingEditionProfileModel printingEditionProfile)
        {
            if (printingEditionProfile is null)
            {
                throw new UserException(Constant.Errors.CREATE_EDITION_FAIL, Enums.ErrorCode.BadRequest);
            }

            AuthorModel author = await _authorService.GetOneAuthorAsync(new AuthorModel { Name = printingEditionProfile.Author });
            if (author is null)
            {
                throw new UserException(Constant.Errors.ENTITY_NOT_FOUND, Enums.ErrorCode.BadRequest);
            }
            PrintingEdition edition = await _printingEditionRepository.CreateAsync(_mapper.Map<PrintingEdition>(printingEditionProfile));
        }

        public async Task<PaginationModel<IEnumerable<PrintingEditionModel>>> GetPrintingEditionAsync(PrintingEditionFilterModel model)
        {

            var mappedDTO = _mapper.Map<PrintingEditionFilterDTO>(model);
            var entities = await _printingEditionRepository.GetFilteredPrintingEditionAsync(mappedDTO).ToListAsync();

            if (!entities.Any())
            {
                throw new UserException(Constant.Errors.ENTITY_NOT_FOUND, Enums.ErrorCode.BadRequest);
            }

            var mappedModel = _mapper.Map<IEnumerable<PrintingEditionModel>>(entities);
            int totalCount = await _printingEditionRepository.GetCountAsync(mappedDTO);

            var pageModel = new PaginationModel<IEnumerable<PrintingEditionModel>>();
            pageModel.Data = mappedModel;
            pageModel.Count = (int)Math.Ceiling((double)totalCount / model.PageSize);
            pageModel.HasNext = model.PageSize * model.PageNumber < totalCount;
            pageModel.HasPrevious = model.PageNumber - Constant.Common.DEFAULT_PAGE_OFFSET > default(int);
            pageModel.PageNumber = model.PageNumber;
            pageModel.PageSize = model.PageSize;

            return pageModel;

        }
    }
}
