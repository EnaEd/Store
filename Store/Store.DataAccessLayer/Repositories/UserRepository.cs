using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.DataAccessLayer.Entities;
using Store.DataAccessLayer.Repositories.Interfaces;
using Store.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Store.DataAccessLayer.Repositories
{
    public class UserRepository : IUserRepository<User>
    {
        private UserManager<User> _userManager;
        private RoleManager<IdentityRole<Guid>> _roleManager;
        public UserRepository(UserManager<User> userManager, RoleManager<IdentityRole<Guid>> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<bool> CheckIsRoleExistAsync(string roleName)
        {
            return await _roleManager.RoleExistsAsync(roleName);
        }

        public async Task<bool> CreateAsync(User item, string password)
        {
            IdentityResult result = await _userManager.CreateAsync(item, password);
            if (!result.Succeeded)
            {
                return result.Succeeded;
            }
            result = await _userManager.AddToRoleAsync(item, UserRole.Client.ToString());

            return result.Succeeded;
        }

        public async Task CreateAsync(User item)
        {
            await _userManager.CreateAsync(item);
        }

        public async Task<bool> CreateRoleAsync(IdentityRole<Guid> role)
        {
            IdentityResult result = await _roleManager.CreateAsync(role);
            return result.Succeeded;
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(User item)
        {
            var res = await _userManager.GenerateEmailConfirmationTokenAsync(item);
            return res;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<IEnumerable<IdentityRole<Guid>>> GetAllRolesAsync()
        {
            return await _roleManager.Roles.ToListAsync();
        }

        public async Task<User> GetOneAsync(Guid id)
        {
            return await _userManager.FindByIdAsync(id.ToString());
        }
        public async Task<User> GetOneAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<User> GetOneAsync(User item)
        {
            return await _userManager.FindByEmailAsync(item.Email);
        }

        public async Task<IdentityRole<Guid>> GetOneRoleAsync(string roleName)
        {
            return await _roleManager.FindByNameAsync(roleName);
        }

        public async Task RemoveOneAsync(User item)
        {
            await _userManager.DeleteAsync(item);
        }

        public async Task RemoveRangeAsync(IEnumerable<User> listItems)
        {
            foreach (var item in listItems)
            {
                await _userManager.DeleteAsync(item);
            }
        }

        public async Task UpdateAsync(User item)
        {
            await _userManager.UpdateAsync(item);
        }

        public async Task<bool> ConfirmEmailAsync(User item, string code)
        {
            var result = await _userManager.ConfirmEmailAsync(item, code);
            return result.Succeeded;
        }

        public async Task<bool> IsEmailConfirmedAsync(User item)
        {
            return await _userManager.IsEmailConfirmedAsync(item);
        }

        public async Task<string> GenerateResetPasswordTokenAsync(User item)
        {
            return await _userManager.GeneratePasswordResetTokenAsync(item);
        }

        public async Task<bool> ResetPasswordAsync(User item, string resetToken, string password)
        {
            var result = await _userManager.ResetPasswordAsync(item, resetToken, password);
            return result.Succeeded;
        }

        public async Task<IList<Claim>> GetUserClaimsAsync(User item)
        {
            return await _userManager.GetClaimsAsync(item);
        }

        public async Task<IList<Claim>> GetRoleClaimsAsync(IdentityRole<Guid> role)
        {

            return await _roleManager.GetClaimsAsync(role);
        }

        public async Task<IList<string>> GetUserRolesAsync(User item)
        {
            return await _userManager.GetRolesAsync(item);
        }
    }
}
