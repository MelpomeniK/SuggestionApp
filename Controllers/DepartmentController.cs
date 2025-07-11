using Microsoft.AspNetCore.Mvc;
using SuggestionApp.Models;
using SuggestionApp.Services;

namespace SuggestionApp.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly DepartmentServices _departmentServices;

        public DepartmentController(DepartmentServices departmentServices)
        {
            _departmentServices = departmentServices;
        }

        // GET: /Department
        public async Task<IActionResult> Index()
        {
            var departments = await _departmentServices.GetDepartmentsAsync();
            return View(departments);
        }

        // GET: /Department/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var department = await _departmentServices.GetDepartmentbyId(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // GET: /Department/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Department/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Department department)
        {
            if (ModelState.IsValid)
            {
                var created = await _departmentServices.CreateDepartmentAsync(department);
                if (created != null)
                    return RedirectToAction(nameof(Index));
            }

            return View(department);
        }

        // GET: /Department/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var department = await _departmentServices.GetDepartmentbyId(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // POST: /Department/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Department department)
        {
            if (id != department.DepartmentId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var updated = await _departmentServices.UpdateDepartmentAsync(department);
                if (updated != null)
                    return RedirectToAction(nameof(Index));
            }

            return View(department);
        }

        // GET: /Department/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var department = await _departmentServices.GetDepartmentbyId(id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: /Department/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var department = await _departmentServices.GetDepartmentbyId(id);
            if (department == null)
            {
                return NotFound();
            }

            var deleted = await _departmentServices.DeleteDepartmentAsync(department);
            if (deleted)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(department);
        }
    }
}
