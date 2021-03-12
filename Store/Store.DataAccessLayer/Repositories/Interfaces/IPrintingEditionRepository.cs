using Store.DataAccessLayer.Entities;
using Store.DataAccessLayer.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Store.DataAccessLayer.Repositories.Interfaces
{
    public interface IPrintingEditionRepository<T> : IBaseRepository<T> where T : class
    {
        public IQueryable<PrintingEdition> GetFilteredPrintingEditionAsync(PrintingEditionFilterDTO filter);
        public Task<int> GetCountAsync(PrintingEditionFilterDTO model);
    }
}
