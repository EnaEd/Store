using System;
using System.Threading.Tasks;

namespace Store.BusinessLogicLayer.Interfaces
{
    public interface IAuthorInPintingEditionService
    {
        public Task AddAuthorToPrintingEditionAsync(Guid authorId, Guid printingEditionId);
    }
}
