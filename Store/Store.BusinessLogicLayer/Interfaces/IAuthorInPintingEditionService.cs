using System;
using System.Threading.Tasks;

namespace Store.BusinessLogicLayer.Interfaces
{
    public interface IAuthorInPintingEditionService
    {
        public Task AddAuthorToPrintingEdition(Guid authorId, Guid printingEditionId);
    }
}
