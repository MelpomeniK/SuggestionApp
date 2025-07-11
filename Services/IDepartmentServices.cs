using SuggestionApp.Models;

namespace SuggestionApp.Services
{
    public interface IDepartmentServices
    {
        Task<List<Department>> GetDepartmentsAsync();
        Task<Department?> GetDepartmentbyId(int id);
        Task<Department?> CreateDepartmentAsync(Department department);
        Task<Department?> UpdateDepartmentAsync(Department department);
        Task<bool> DeleteDepartmentAsync(Department department);
    }
}