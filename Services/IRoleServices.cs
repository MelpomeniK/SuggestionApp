using Microsoft.EntityFrameworkCore;
using SuggestionApp.Models;

namespace SuggestionApp.Services
{
    public interface IRoleServices
    {
        Task<List<Role>> GetRolesAsync();
        Task<Role?> GetRoleById(int id);
        Task<Role?> CreateRoleAsync(Role role);
        Task<Role?> UpdateRoleAsync(Role role);
        Task<bool> DeleteRoleAsync(Role role);
        Task<int> GetManagerCountAsync();

    }
}