using Microsoft.AspNetCore.Identity;
using Store.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Security.Claims;
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
        public Task<IList<Claim>> GetUserClaimsAsync(T item);
        public Task<IList<Claim>> GetRoleClaimsAsync(IdentityRole<Guid> role);
        public Task<IList<string>> GetUserRolesAsync(T item);
        public Task<IEnumerable<UserProfileEntity>> GetFilteredUserProfilesAsync(UserFilterEntity filterEntity = null);

    }
}
