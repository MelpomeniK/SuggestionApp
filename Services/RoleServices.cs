using Microsoft.EntityFrameworkCore;
using SuggestionApp.Data;
using SuggestionApp.Models;
using System.Runtime.InteropServices;

namespace SuggestionApp.Services
{
    public class RoleServices : IRoleServices 
    {
        private readonly AppDbContext _context;

        public RoleServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Role>> GetRolesAsync()
        {
            var roles = await _context.Roles.ToListAsync();
            return roles;
        }

        public async Task<Role> GetRoleById(int id)
        {
            var roles = await _context.Roles.FirstOrDefaultAsync(r => r.RoleId == id);
            return roles;
        }

        public async Task<Role?> CreateRoleAsync(Role role)
        {
            try
            {
                var rol = await _context.Roles.AddAsync(role);
                await _context.SaveChangesAsync();
                return role;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public async Task<Role?> UpdateRoleAsync(Role role)
        {
            try
            {
                var rol = await _context.Roles.FirstOrDefaultAsync(r => r.RoleId == role.RoleId);
                if(rol != null)
                {
                    var uprol = _context.Roles.Update(role);
                    await _context.SaveChangesAsync();
                    return role;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public async Task<bool> DeleteRoleAsync(Role role)
        {
            try
            {
                var rol = await _context.Roles.FirstOrDefaultAsync(r => r.RoleId == role.RoleId);
                if(rol != null)
                {
                    _context.Roles.Remove(rol);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<int> GetManagerCountAsync()
        {
            return await _context.Roles.CountAsync(r => r.IsManager == true);
        }
    }
}
