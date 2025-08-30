using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SuggestionApp.Data;
using SuggestionApp.Models;
using SuggestionApp.Services;

namespace SuggestionApp.Controllers
{
    public class RoleController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IDepartmentServices _departmentServices;

        public RoleController(AppDbContext context, IDepartmentServices departmentServices)
        {
            _context = context;
            _departmentServices = departmentServices;
        }

        // GET: Role
        public async Task<IActionResult> Index()
        {
            var roles = await _context.Roles
                .Include(r => r.Department) // eager load department
                .ToListAsync();
            return View(roles);
        }

        // GET: Role/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var role = await _context.Roles
                .Include(r => r.Department)
                .FirstOrDefaultAsync(r => r.RoleId == id);

            if (role == null)
                return NotFound();

            return View(role);
        }

        // GET: Role/Create
        public async Task<IActionResult> Create()
        {
            var departments = await _departmentServices.GetDepartmentsAsync();
            ViewBag.Departments = new SelectList(departments, "DepartmentId", "DepartmentName");
            return View();
        }

        // POST: Role/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoleId,RoleName,isActive,DepartmentId,IsManager")] Role role)
        {
            if (ModelState.IsValid)
            {
                _context.Add(role);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // repopulate dropdown if error
            var departments = await _departmentServices.GetDepartmentsAsync();
            ViewBag.Departments = new SelectList(departments, "DepartmentId", "DepartmentName", role.DepartmentId);
            return View(role);
        }

        // GET: Role/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var role = await _context.Roles.FindAsync(id);
            if (role == null)
                return NotFound();

            var departments = await _departmentServices.GetDepartmentsAsync();
            ViewBag.Departments = new SelectList(departments, "DepartmentId", "DepartmentName", role.DepartmentId);

            return View(role);
        }

        // POST: Role/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoleId,RoleName,isActive,DepartmentId,IsManager")] Role role)
        {
            if (id != role.RoleId)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(role);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoleExists(role.RoleId))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            var departments = await _departmentServices.GetDepartmentsAsync();
            ViewBag.Departments = new SelectList(departments, "DepartmentId", "DepartmentName", role.DepartmentId);

            return View(role);
        }

        // GET: Role/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var role = await _context.Roles
                .Include(r => r.Department)
                .FirstOrDefaultAsync(m => m.RoleId == id);

            if (role == null)
                return NotFound();

            return View(role);
        }

        // POST: Role/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role != null)
            {
                _context.Roles.Remove(role);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool RoleExists(int id)
        {
            return _context.Roles.Any(e => e.RoleId == id);
        }
    }
}
