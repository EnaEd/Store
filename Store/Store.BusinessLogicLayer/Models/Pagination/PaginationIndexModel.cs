using Store.BusinessLogicLayer.Models.PrintingEdition;
using System.Collections.Generic;

namespace Store.BusinessLogicLayer.Models.Pagination
{
    public class PaginationIndexModel
    {
        public IEnumerable<PrintingEditionModel> PrintingEditions { get; set; }
        public PaginationPageModel Page { get; set; }
    }
}
