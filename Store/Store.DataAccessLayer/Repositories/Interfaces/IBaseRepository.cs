using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.DataAccessLayer.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetOneAsync(Guid id);
        public Task<T> GetOneAsync(T item);
        public Task CreateAsync(T item);
        public Task UpdateAsync(T item);
        public Task RemoveOneAsync(T item);
        public Task RemoveRangeAsync(IEnumerable<T> listItems);
    }
}
