using Microsoft.EntityFrameworkCore;
using Store.DataAccessLayer.AppContext;
using Store.DataAccessLayer.Entities;
using Store.DataAccessLayer.Repositories.Base;
using Store.DataAccessLayer.Repositories.Interfaces;
using System.Threading.Tasks;

namespace Store.DataAccessLayer.Repositories
{
    public class AuthorRepository : BaseEFRepository<Author>, IAuthorRepository<Author>
    {
        //private readonly ApplicationContext _context;
        private readonly DbSet<Author> _dbSet;
        public AuthorRepository(ApplicationContext context) : base(context)
        {
            //_context = context;
            _dbSet = context.Set<Author>();
        }

        public async Task<Author> GetOneAsync(string authorName)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Name.Equals(authorName));
        }
    }
}
