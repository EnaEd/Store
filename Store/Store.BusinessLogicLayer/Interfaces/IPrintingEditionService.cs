using Store.BusinessLogicLayer.Models.PrintingEdition;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.BusinessLogicLayer.Interfaces
{
    public interface IPrintingEditionService
    {
        public Task<IEnumerable<PrintingEditionModel>> GetPrintingEdition(PrintingEditionFilterModel filter = null);
    }
}
