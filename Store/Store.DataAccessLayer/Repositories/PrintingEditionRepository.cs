using Store.DataAccessLayer.AppContext;
using Store.DataAccessLayer.Entities;
using Store.DataAccessLayer.Repositories.Base;
using Store.DataAccessLayer.Repositories.Interfaces;

namespace Store.DataAccessLayer.Repositories
{
    public class PrintingEditionRepository : BaseEFRepository<PrintingEdition>, IPrintingEditionRepository<PrintingEdition>
    {
        public PrintingEditionRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }
    }
}
