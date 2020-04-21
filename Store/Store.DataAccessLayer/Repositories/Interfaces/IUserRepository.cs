using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.DataAccessLayer.Repositories.Interfaces
{
    public interface IUserRepository<T> : IBaseRepository<T> where T : class
    {
        public Task<IEnumerable<IdentityRole<Guid>>> GetAllRolesAsync();
        public Task<IdentityRole<Guid>> GetOneRoleAsync(string roleName);
        public Task<bool> CheckIsRoleExistAsync(string roleName);
        public Task<bool> CreateRoleAsync(IdentityRole<Guid> role);
        public Task<bool> CreateAsync(T item, string password);
        public Task<string> GenerateEmailConfirmationTokenAsync(T item);
        public Task<bool> ConfirmEmailAsync(T item, string code);
        public Task<T> GetOneAsync(string email);
        public Task<bool> IsEmailConfirmedAsync(T item);
        public Task<string> GenerateResetPasswordTokenAsync(T item);
        public Task<bool> ResetPasswordAsync(T item, string resetToken, string password);

    }
}
