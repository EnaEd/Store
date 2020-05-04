using Store.BusinessLogicLayer.Models.Pagination;
using Store.BusinessLogicLayer.Models.PrintingEdition;
using System.Threading.Tasks;

namespace Store.BusinessLogicLayer.Interfaces
{
    public interface IPrintingEditionService
    {
        public Task<PaginationIndexModel> GetPrintingEdition(PrintingEditionFilterModel filter = null);
    }
}
