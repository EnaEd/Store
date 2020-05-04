using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Store.DataAccessLayer.AppContext;
using Store.DataAccessLayer.Entities;
using Store.DataAccessLayer.Models;
using Store.DataAccessLayer.Repositories.Base;
using Store.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.DataAccessLayer.Repositories
{
    public class PrintingEditionRepository : BaseEFRepository<PrintingEdition>, IPrintingEditionRepository<PrintingEdition>
    {
        public PrintingEditionRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

        public async Task<IEnumerable<PrintingEdition>> GetFilteredPrintingEditionAsync(PrintingEditionFilterModelDAL filter = null)
        {
            var Currency = new SqlParameter("@Currency", filter?.Currency ?? (object)DBNull.Value);
            var Description = new SqlParameter("@Description", filter?.Description ?? (object)DBNull.Value);
            var Status = new SqlParameter("@Status", filter?.Status ?? (object)DBNull.Value);
            var Title = new SqlParameter("@Title", filter?.Title ?? (object)DBNull.Value);
            var Type = new SqlParameter("@Type", filter?.Type ?? (object)DBNull.Value);
            var MinPrice = new SqlParameter("@MinPrice", filter?.Price?.MinPrice ?? (object)DBNull.Value);
            var MaxPrice = new SqlParameter("@MaxPrice", filter?.Price.MaxPrice ?? (object)DBNull.Value);
            var Author = new SqlParameter("@Author", filter?.Author ?? (object)DBNull.Value);

            return await Task.Run(() => _context.PrintingEditions.FromSqlRaw(
               $"spGetFilteredPrintingEdition @Currency,@Description,@Status,@Title,@Type,@MinPrice,@MaxPrice,@Author",
               Currency, Description, Status, Title, Type, MinPrice, MaxPrice, Author)
               .ToListAsync());
        }

    }
}
