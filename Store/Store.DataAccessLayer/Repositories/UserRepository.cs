using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.DataAccessLayer.Entities;
using Store.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.DataAccessLayer.Repositories
{
    public class UserRepository : IUserRepository<User>
    {
        private UserManager<User> _userManager;
        private RoleManager<IdentityRole<Guid>> _roleManager;
        private SignInManager<User> _signInManager;
        public UserRepository(UserManager<User> userManager, RoleManager<IdentityRole<Guid>> roleManager,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<bool> CheckIsRoleExistAsync(string roleName)
        {
            return await _roleManager.RoleExistsAsync(roleName);
        }

        public async Task<bool> CreateAsync(User item, string password)
        {
            IdentityResult result = await _userManager.CreateAsync(item, password);
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
    }
}
