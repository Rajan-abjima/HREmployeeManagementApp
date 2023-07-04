using Management.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeHandler.Controllers;
public class AdminEmployeeController : Controller
{
    private readonly IEmployeeRepository _employeeRepository;

    public AdminEmployeeController(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<IActionResult> EmployeeList()
    {
        var result = await _employeeRepository.GetAllEmployeesAsync();
        return View(result);
    }
}
