using AutoMapper;
using Store.BusinessLogicLayer.Interfaces;
using Store.BusinessLogicLayer.Models.Pagination;
using Store.BusinessLogicLayer.Models.PrintingEdition;
using Store.DataAccessLayer.Entities;
using Store.DataAccessLayer.Models;
using Store.DataAccessLayer.Repositories.Interfaces;
using Store.Shared.Constants;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.BusinessLogicLayer.Services
{
    public class PrintingEditionService : IPrintingEditionService
    {
        private readonly IPrintingEditionRepository<PrintingEdition> _printingEditionRepository;
        private readonly IMapper _mapper;

        public PrintingEditionService(IPrintingEditionRepository<PrintingEdition> printingEditionRepository, IMapper mapper)
        {
            _printingEditionRepository = printingEditionRepository;
            _mapper = mapper;
        }

        public async Task<PaginationIndexModel> GetPrintingEdition(PrintingEditionFilterModel model = null)
        {


            PrintingEditionFilterModelDAL filter = model is null ? null : _mapper.Map<PrintingEditionFilterModelDAL>(model);
            IEnumerable<PrintingEditionModel> sourceEditions = _mapper.Map<IEnumerable<PrintingEditionModel>>(
                await _printingEditionRepository.GetFilteredPrintingEditionAsync(filter));

            int count = sourceEditions.ToList().Count();

            IEnumerable<PrintingEditionModel> editions = sourceEditions
                .Skip((
                (model?.PageNumber - Constant.Common.ARRAY_INDEX_OFFSET) ?? default(int))
                * model?.PageSize ?? default(int))
                .Take((model?.PageSize ?? 10));

            PaginationPageModel pageModel = new PaginationPageModel(count,
                (model?.PageNumber ?? Constant.PaginationConfig.DEFAULT_PAGE_NUMBER),
                (model?.PageSize ?? Constant.PaginationConfig.DEFAULT_ITEM_PER_PAGE));

            return new PaginationIndexModel { Page = pageModel, PrintingEditions = editions };
        }
    }
}
