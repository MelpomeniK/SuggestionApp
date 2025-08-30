using Microsoft.EntityFrameworkCore;
using SuggestionApp.Data;
using SuggestionApp.Models;

namespace SuggestionApp.Services
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly AppDbContext _context;

        public DepartmentServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> GetDepartmentsAsync()
        {
            var departments = await _context.Departments.ToListAsync();
            return departments;
        }
        public async Task<Department> GetDepartmentbyId(int id)
        {
            var department = await _context.Departments.FirstOrDefaultAsync(d => d.DepartmentId == id);
            return department;
        }

        public async Task<Department?> CreateDepartmentAsync(Department department)
        {
            try
            {
                var dep = await _context.Departments.AddAsync(department);
                await _context.SaveChangesAsync();
                return department;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public async Task<Department?> UpdateDepartmentAsync(Department department)
        {
            try
            {
                var dep = await _context.Departments.FirstOrDefaultAsync(d => d.DepartmentId == department.DepartmentId);
                if (dep != null)
                {
                    dep.DepartmentName = department.DepartmentName;
                    dep.Description = department.Description;
                    dep.isActive = department.isActive;

                    await _context.SaveChangesAsync();
                    return dep;
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

        public async Task<bool> DeleteDepartmentAsync(Department department)
        {
            try
            {
                var dep = await _context.Departments.FirstOrDefaultAsync(d => d.DepartmentId == department.DepartmentId);
                if (dep != null)
                {
                    _context.Departments.Remove(dep);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
