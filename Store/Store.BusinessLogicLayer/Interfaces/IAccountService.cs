﻿using Store.DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.BusinessLogicLayer.Interfaces
{
    public interface IAccountService
    {
        public Task<IEnumerable<User>> GetUsers();
    }
}
