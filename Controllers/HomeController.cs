using Microsoft.AspNetCore.Mvc;
using SuggestionApp.Services;
using SuggestionApp.Models;
using SuggestionApp.ViewModels; 

public class HomeController : Controller
{
    private readonly IDepartmentServices _departmentServices;
    private readonly ISuggestionServices _suggestionServices;
    private readonly IRoleServices _roleServices;

    public HomeController(
    IDepartmentServices departmentServices,
    ISuggestionServices suggestionServices,
    IRoleServices roleServices) // 
    {
        _departmentServices = departmentServices;
        _suggestionServices = suggestionServices;
        _roleServices = roleServices; 
    }

    public async Task<IActionResult> Index()
    {
        var managerRoleCount = await _roleServices.GetManagerCountAsync();
        var suggestions = await _suggestionServices.GetSuggestionsAsync();
        var departments = await _departmentServices.GetDepartmentsAsync();

        var viewModel = new DashboardViewModel
        {
            DepartmentCount = departments.Count,
            DepartmentManagers = departments
                .Where(d => !string.IsNullOrWhiteSpace(d.ManagerName))
                .Select(d => d.ManagerName)
                .Distinct()
                .ToList(),
            TotalSuggestions = suggestions.Count,
            AcceptedSuggestions = suggestions.Count(s => s.isApproved == true),
            RejectedSuggestions = suggestions.Count(s => s.isApproved == false),
            PendingSuggestions = suggestions.Count(s => s.isApproved == null),
            ManagerRoleCount = managerRoleCount 
        };

        return View(viewModel);
    }
}