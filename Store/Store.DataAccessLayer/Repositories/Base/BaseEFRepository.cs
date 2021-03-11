using Microsoft.EntityFrameworkCore;
using Store.DataAccessLayer.AppContext;
using Store.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.DataAccessLayer.Repositories.Base
{
    public class BaseEFRepository<T> : IBaseRepository<T> where T : class
    {
        public readonly ApplicationContext _context;
        public readonly DbSet<T> _dbSet;

        public BaseEFRepository(ApplicationContext applicationContext)
        {
            _context = applicationContext;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> CreateAsync(T item)
        {
            _dbSet.Add(item);
            await _context.SaveChangesAsync();
            var result = _dbSet.AsEnumerable().Last();
            return result;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            var result = await _dbSet.ToListAsync();
            return result;
        }



        public virtual async Task<T> GetOneAsync(Guid id)
        {
            var result = await _dbSet.FindAsync(id);
            return result;
        }

        public async Task<T> GetOneAsync(T item)
        {
            var result = await _dbSet.FindAsync(item);
            return result;
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
