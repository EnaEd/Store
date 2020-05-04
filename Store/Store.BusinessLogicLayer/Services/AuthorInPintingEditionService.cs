using Store.BusinessLogicLayer.Interfaces;
using Store.DataAccessLayer.Entities;
using Store.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace Store.BusinessLogicLayer.Services
{
    public class AuthorInPintingEditionService : IAuthorInPintingEditionService
    {
        private readonly IAuthorInPrintingEditionRepository<AuthorInPrintingEdition> _authorInPrintingEditionRepository;

        public AuthorInPintingEditionService(IAuthorInPrintingEditionRepository<AuthorInPrintingEdition> authorInPrintingEditionRepository)
        {
            _authorInPrintingEditionRepository = authorInPrintingEditionRepository;
        }

        public async Task AddAuthorToPrintingEdition(Guid authorId, Guid printingEditionId)
        {
            AuthorInPrintingEdition item = new AuthorInPrintingEdition
            {
                AuthorId = authorId,
                Date = DateTime.UtcNow,
                PrintingEditionId = printingEditionId
            };
            await _authorInPrintingEditionRepository.CreateAsync(item);
        }
    }
}
