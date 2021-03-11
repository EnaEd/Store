using Microsoft.EntityFrameworkCore;
using Store.DataAccessLayer.AppContext;
using Store.DataAccessLayer.Entities;
using Store.DataAccessLayer.Repositories.Base;
using Store.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace Store.DataAccessLayer.Repositories
{
    public class AuthorRepository : BaseEFRepository<Author>, IAuthorRepository<Author>
    {
        public AuthorRepository(ApplicationContext context) : base(context)
        {
        }

        public override async Task<Author> GetOneAsync(Guid id)
        {
            var result = await _dbSet.AsNoTracking().FirstAsync(x => x.Id == id);
            return result;
        }
        public async Task<Author> GetOneAsync(string authorName)
        {
            var result = await _dbSet.FirstOrDefaultAsync(x => EF.Functions.Like(authorName, authorName));
            return result;
        }
    }
}
