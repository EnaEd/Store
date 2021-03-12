using Microsoft.EntityFrameworkCore;
using Store.DataAccessLayer.AppContext;
using Store.DataAccessLayer.Entities;
using Store.DataAccessLayer.Models;
using Store.DataAccessLayer.Repositories.Base;
using Store.DataAccessLayer.Repositories.Interfaces;
using Store.Shared.Constants;
using Store.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.DataAccessLayer.Repositories
{
    public class PrintingEditionRepository : BaseEFRepository<PrintingEdition>, IPrintingEditionRepository<PrintingEdition>
    {
        public PrintingEditionRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

        public override async Task<PrintingEdition> GetOneAsync(Guid id)
        {
            var result = await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public override async Task CreateAsync(PrintingEdition item)
        {
            //TODO EE: improve this after implement delete method
            var authors = new List<Author>(item.Authors);
            item.Authors.Clear();
            _dbSet.Add(item);
            item.Authors.AddRange(authors);
            await SaveChangesAsync();
        }

        public async Task<int> GetCountAsync(PrintingEditionFilterDTO model)
        {
            var query = _dbSet
                .Where(x => model.Title == null || x.Title.Contains(model.Title))
                .Where(x => model.Description == null || x.Description.Contains(model.Description))
                .Where(x => model.Currency == default || x.Currency.Equals(model.Currency.ToString()))
                .Where(x => model.Status == default || x.Status.Equals(model.Status.ToString()))
                .Where(x => model.Type == default || x.Type.Equals(model.Type.ToString()))
                .Where(x => x.Price >= model.Price.MinPrice && x.Price <= model.Price.MaxPrice)
                .Where(x => model.Author == null || x.Authors.Any(author => author.Name.Equals(model.Author)));

            int result = await query.CountAsync();
            return result;
        }

        public IQueryable<PrintingEdition> GetFilteredPrintingEditionAsync(PrintingEditionFilterDTO filter)
        {
            var query = _dbSet.Include(edition => edition.Authors)
                        .Where(x => filter.Title == null || x.Title.Contains(filter.Title))
                        .Where(x => filter.Description == null || x.Description.Contains(filter.Description))
                        .Where(x => filter.Currency == default || x.Currency.Equals(filter.Currency.ToString()))
                        .Where(x => filter.Status == default || x.Status.Equals(filter.Status.ToString()))
                        .Where(x => filter.Type == default || x.Type.Equals(filter.Type.ToString()))
                        .Where(x => x.Price >= filter.Price.MinPrice && x.Price <= filter.Price.MaxPrice)
                        .Where(x => filter.Author == null || x.Authors.Any(author => author.Name.Equals(filter.Author)))
                        .OrderByExtension(filter.OrderField, filter.OrderByDesc).Skip((filter.PageNumber - Constant.Common.DEFAULT_PAGE_OFFSET) * filter.PageSize).Take(filter.PageSize);

            return query;
        }

    }
}
