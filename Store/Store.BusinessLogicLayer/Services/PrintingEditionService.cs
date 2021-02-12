using AutoMapper;
using Store.BusinessLogicLayer.Interfaces;
using Store.BusinessLogicLayer.Models.Author;
using Store.BusinessLogicLayer.Models.Pagination;
using Store.BusinessLogicLayer.Models.PrintingEdition;
using Store.DataAccessLayer.Entities;
using Store.DataAccessLayer.Models;
using Store.DataAccessLayer.Repositories.Interfaces;
using Store.Shared.Common;
using Store.Shared.Constants;
using Store.Shared.Enums;
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
                throw new UserException(Constant.Errors.AUTHOR_NOT_FOUND, Enums.ErrorCode.BadRequest);
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
                throw new UserException(Constant.Errors.AUTHOR_NOT_FOUND, Enums.ErrorCode.BadRequest);
            }
            PrintingEdition edition = await _printingEditionRepository.CreateAsync(_mapper.Map<PrintingEdition>(printingEditionProfile));
        }

        public async Task<PaginationIndexModel> GetPrintingEditionAsync(PrintingEditionFilterModel model = null)
        {


            PrintingEditionFilterModelDAL filter = model is null ? null : _mapper.Map<PrintingEditionFilterModelDAL>(model);
            IEnumerable<PrintingEditionModel> sourceEditions = _mapper.Map<IEnumerable<PrintingEditionModel>>(
                await _printingEditionRepository.GetFilteredPrintingEditionAsync(filter));

            int count = sourceEditions.ToList().Count();

            IEnumerable<PrintingEditionModel> editions = sourceEditions
                .Skip((
                (model?.PageNumber - Constant.Common.ARRAY_INDEX_OFFSET) ?? default)
                * model?.PageSize ?? default)
                .Take((model?.PageSize ?? 10));

            PaginationPageModel pageModel = new PaginationPageModel(count,
                (model?.PageNumber ?? Constant.PaginationConfig.DEFAULT_PAGE_NUMBER),
                (model?.PageSize ?? Constant.PaginationConfig.DEFAULT_ITEM_PER_PAGE));

            return new PaginationIndexModel { Page = pageModel, PrintingEditions = editions };
        }
    }
}
