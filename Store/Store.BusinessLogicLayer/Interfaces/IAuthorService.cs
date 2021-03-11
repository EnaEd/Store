using Store.BusinessLogicLayer.Models.Author;
using Store.BusinessLogicLayer.Models.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.BusinessLogicLayer.Interfaces
{
    public interface IAuthorService
    {
        public Task<PaginationModel<IEnumerable<AuthorModel>>> GetAuthorsAsync(AuthorFilterModel model);
        public Task<AuthorModel> GetOneAuthorAsync(Guid id);
        public Task<AuthorModel> GetOneAuthorAsync(AuthorModel author);
        public Task RemoveAuthorAsync(AuthorModel author);
        public Task CreateAuthorAsync(AuthorModel author);
        public Task UpdateAuthorAsync(AuthorModel author);
    }
}
