using System;

namespace Store.BusinessLogicLayer.Models.Base
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public bool IsRemoved { get; set; }
    }
}
