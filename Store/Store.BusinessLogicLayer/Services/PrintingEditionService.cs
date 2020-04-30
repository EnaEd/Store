using AutoMapper;
using Store.BusinessLogicLayer.Interfaces;
using Store.BusinessLogicLayer.Models.PrintingEdition;
using Store.DataAccessLayer.Entities;
using Store.DataAccessLayer.Models;
using Store.DataAccessLayer.Repositories.Interfaces;
using System.Collections.Generic;
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

        public async Task<IEnumerable<PrintingEditionModel>> GetPrintingEdition(PrintingEditionFilterModel model = null)
        {
            //TODO EE: refactoring
            return model is null ?
                _mapper.Map<IEnumerable<PrintingEditionModel>>(await _printingEditionRepository.GetFilteredPrintingEditionAsync()) :
                _mapper.Map<IEnumerable<PrintingEditionModel>>(await _printingEditionRepository.GetFilteredPrintingEditionAsync(
                    _mapper.Map<PrintingEditionFilterModelDAL>(model)));
        }
    }
}
