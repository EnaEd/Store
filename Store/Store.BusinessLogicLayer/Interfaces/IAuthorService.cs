using Store.BusinessLogicLayer.Models.Author;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.BusinessLogicLayer.Interfaces
{
    public interface IAuthorService
    {
        public Task<IEnumerable<AuthorModel>> GetAuthorsAsync();
        //public Task
    }
}
