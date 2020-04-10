using Microsoft.EntityFrameworkCore;
using Store.DataAccessLayer.AppContext;
using Store.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.DataAccessLayer.Repositories.Base
{
    public class BaseEFRepository<T> : IBaseRepository<T> where T : class
    {
        private ApplicationContext _context;
        private DbSet<T> _dbSet;

        public BaseEFRepository(ApplicationContext applicationContext)
        {
            _context = applicationContext;
            _dbSet = _context.Set<T>();
        }

        public async Task CreateAsync(T item)
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetOneAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> GetOneAsync(T item)
        {
            return await _dbSet.FindAsync(item);
        }

        public async Task RemoveOneAsync(T item)
        {
            _dbSet.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<T> listItems)
        {
            _dbSet.RemoveRange(listItems);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T item)
        {
            _dbSet.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
