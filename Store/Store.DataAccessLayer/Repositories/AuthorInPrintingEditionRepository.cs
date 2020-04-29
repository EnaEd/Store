using Microsoft.EntityFrameworkCore;
using Store.DataAccessLayer.AppContext;
using Store.DataAccessLayer.Entities;
using Store.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.DataAccessLayer.Repositories
{
    public class AuthorInPrintingEditionRepository : IAuthorInPrintingEditionRepository<AuthorInPrintingEdition>
    {
        private ApplicationContext _context;
        private DbSet<AuthorInPrintingEdition> _dbSet;

        public AuthorInPrintingEditionRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<AuthorInPrintingEdition>();
        }

        public async Task CreateAsync(AuthorInPrintingEdition item)
        {
            _dbSet.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AuthorInPrintingEdition>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<AuthorInPrintingEdition> GetOneAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<AuthorInPrintingEdition> GetOneAsync(AuthorInPrintingEdition item)
        {
            return await _dbSet.FindAsync(item);
        }

        public async Task RemoveOneAsync(AuthorInPrintingEdition item)
        {
            _dbSet.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<AuthorInPrintingEdition> listItems)
        {
            _dbSet.RemoveRange(listItems);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(AuthorInPrintingEdition item)
        {
            _dbSet.Update(item);
            await _context.SaveChangesAsync();

        }
    }
}
