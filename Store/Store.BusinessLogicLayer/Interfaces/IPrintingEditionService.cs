using Store.BusinessLogicLayer.Models.Base;
using Store.BusinessLogicLayer.Models.PrintingEdition;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.BusinessLogicLayer.Interfaces
{
    public interface IPrintingEditionService
    {
        public Task<PaginationModel<IEnumerable<PrintingEditionModel>>> GetPrintingEditionAsync(PrintingEditionFilterModel model);
        public Task CreatePrintingEditionAsync(PrintingEditionRequestModel printingEditionProfile);
        public Task UpdatePrintingEditionAsync(PrintingEditionRequestModel printingEditionProfile);
        public Task DeletePrintingEditionAsync(PrintingEditionRequestModel printingEditionProfile);
    }
}
