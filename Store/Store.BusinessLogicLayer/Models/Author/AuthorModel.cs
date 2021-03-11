using Store.BusinessLogicLayer.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Store.BusinessLogicLayer.Models.Author
{
    public class AuthorModel : BaseModel
    {
        [Required]
        public string Name { get; set; }
    }
}
