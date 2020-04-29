using Microsoft.EntityFrameworkCore;
using Store.DataAccessLayer.AppContext;
using Store.DataAccessLayer.Entities;
using Store.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.DataAccessLayer.Repositories
{
    public class AuthorRepository : IAuthorRepository<Author>
    {
        private ApplicationContext _context;
        private DbSet<Author> _authors;

        public AuthorRepository(ApplicationContext context)
        {
            _context = context;
            _authors = context.Set<Author>();
        }

        public async Task CreateAsync(Author item)
        {
            _authors.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _authors.ToListAsync();
        }

        public async Task<Author> GetOneAsync(Guid id)
        {
            return await _authors.FindAsync(id);
        }

        public async Task<Author> GetOneAsync(Author item)
        {
            return await _authors.FindAsync(item);
        }

        public async Task RemoveOneAsync(Author item)
        {
            _authors.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<Author> listItems)
        {
            _authors.RemoveRange(listItems);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Author item)
        {
            _authors.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
