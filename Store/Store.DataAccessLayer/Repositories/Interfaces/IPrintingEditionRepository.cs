using Store.DataAccessLayer.Entities;
using Store.DataAccessLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.DataAccessLayer.Repositories.Interfaces
{
    public interface IPrintingEditionRepository<T> : IBaseRepository<T> where T : class
    {
        public Task<IEnumerable<PrintingEdition>> GetFilteredPrintingEditionAsync(PrintingEditionFilterModelDAL printingEditionFilterModel = null);
    }
}
