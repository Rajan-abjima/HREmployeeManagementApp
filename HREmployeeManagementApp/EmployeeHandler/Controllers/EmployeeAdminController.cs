using Management.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace EmployeeHandler.Controllers;
public class EmployeeAdminController : Controller
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeAdminController(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    [HttpGet]
    public async Task<IActionResult> EmployeeList()
    {
        var result = await _employeeRepository.GetAllEmployeesAsync();
        return View(result);
    }
}
