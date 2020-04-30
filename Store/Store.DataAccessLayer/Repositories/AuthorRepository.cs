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
        public AuthorRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<Author> GetOneAsync(string authorName)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Name.Equals(authorName));
        }
    }
}
