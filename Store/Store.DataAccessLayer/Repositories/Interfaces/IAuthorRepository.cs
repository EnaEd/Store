using System.Threading.Tasks;

namespace Store.DataAccessLayer.Repositories.Interfaces
{
    public interface IAuthorRepository<T> : IBaseRepository<T> where T : class
    {
        public Task<T> GetOneAsync(string authorName);
    }
}
