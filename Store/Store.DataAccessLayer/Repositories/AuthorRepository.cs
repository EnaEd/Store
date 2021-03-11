using Microsoft.EntityFrameworkCore;
using Store.DataAccessLayer.AppContext;
using Store.DataAccessLayer.Entities;
using Store.DataAccessLayer.Models;
using Store.DataAccessLayer.Repositories.Base;
using Store.DataAccessLayer.Repositories.Interfaces;
using Store.Shared.Constants;
using Store.Shared.Extensions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Store.DataAccessLayer.Repositories
{
    public class AuthorRepository : BaseEFRepository<Author>, IAuthorRepository<Author>
    {
        public AuthorRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<int> GetCount(AuthorFilterDTO model)
        {
            int result = await _dbSet.Where(author => author.Name.Contains(model.NameFilter)).CountAsync();
            return result;
        }

        public IQueryable<Author> GetAllFiltered(AuthorFilterDTO model)
        {
            var result =
                _dbSet.Where(author => model.NameFilter == null || author.Name.Contains(model.NameFilter))
                .OrderByExtension(model.OrderField, model.OrderByDesc)
                .Skip((model.PageNumber - Constant.Common.DEFAULT_PAGE_OFFSET) * model.PageSize)
                .Take(model.PageSize);

            return result;
        }

        public override async Task<Author> GetOneAsync(Guid id)
        {
            var result = await _dbSet.AsNoTracking().FirstAsync(x => x.Id == id);
            return result;
        }


        public async Task<Author> GetOneAsync(string authorName)
        {
            var result = await _dbSet.FirstOrDefaultAsync(x => EF.Functions.Like(x.Name, authorName));
            return result;
        }
    }
}
