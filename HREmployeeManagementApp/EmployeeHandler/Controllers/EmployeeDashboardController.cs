using Management.Application.Interfaces;
using Management.Entities.EmployeeEntities;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeHandler.Controllers;
public class EmployeeDashboardController : Controller
{
    private readonly IEmployeeDashboardRepository _employeeDashboardRepository;

    public EmployeeDashboardController(IEmployeeDashboardRepository employeeDashboardRepository)
    {
        _employeeDashboardRepository = employeeDashboardRepository;
    }

    public IActionResult EmployeeDashboard()
    {
        return View();
    }

    public async Task<IActionResult> EmployeeDataByID(int employeeID)
    {
        var employeeData = await _employeeDashboardRepository.GetByIDAsync(employeeID);
        return View (employeeData);
    }
}
