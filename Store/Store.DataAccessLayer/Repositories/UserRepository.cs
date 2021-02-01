using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Store.DataAccessLayer.AppContext;
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
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly ApplicationContext _context;
        public UserRepository(UserManager<User> userManager, RoleManager<IdentityRole<Guid>> roleManager, ApplicationContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
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
            result = await _userManager.AddToRoleAsync(item, Enums.UserRole.Client.ToString());

            return result.Succeeded;
        }
        public async Task<User> CreateAsync(User item)
        {
            await _userManager.CreateAsync(item);
            return await _userManager.FindByEmailAsync(item.Email);
        }
        public async Task<bool> CreateRoleAsync(IdentityRole<Guid> role)
        {
            IdentityResult result = await _roleManager.CreateAsync(role);
            return result.Succeeded;
        }
        public async Task<string> GenerateEmailConfirmationTokenAsync(User item)
        {
            string res = await _userManager.GenerateEmailConfirmationTokenAsync(item);
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
        public async Task<IEnumerable<UserProfileEntity>> GetFilteredUserProfilesAsync(UserFilterEntity filterEntity)
        {
            var Email = new SqlParameter("@Email", filterEntity?.Email ?? (object)DBNull.Value);
            var FirstName = new SqlParameter("@FirstName", filterEntity?.FirstName ?? (object)DBNull.Value);
            var LastActivity = new SqlParameter("@LastActivity", filterEntity?.LastActivity ?? (object)DBNull.Value);
            var LastName = new SqlParameter("@LastName", filterEntity?.LastName ?? (object)DBNull.Value);
            var LastOrderDate = new SqlParameter("@LastOrderDate", filterEntity?.LastOrderDate ?? (object)DBNull.Value);
            var RegistrationDate = new SqlParameter("@RegistrationDate", filterEntity?.RegistrationDate ?? (object)DBNull.Value);
            var Role = new SqlParameter("@Role", filterEntity?.Role ?? (object)DBNull.Value);

            return await Task.Run(() => _context.Set<UserProfileEntity>().FromSqlRaw(
               $"spGetFilteredUser @FirstName,@LastName,@Email,@LastActivity,@LastOrderDate,@RegistrationDate,@Role",
               FirstName, LastName, Email, LastActivity, LastOrderDate, RegistrationDate, Role)
               .ToListAsync());
        }

    }
}
