using Management.Application.Interfaces;
using Management.Entities.AdminEntities;
using Management.Entities.EmployeeEntities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;
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

    [HttpGet]
    public async Task<IActionResult> EmployeeDetailsUpdate(int EmployeeID)
    {
        var employeeData = await _employeeRepository.GetEmployeeByIdAsync(EmployeeID);
        return View(employeeData);
    }

    [HttpPost]
    public async Task<IActionResult> EmployeeDetailsUpdate(EmployeeAdmin employee)
    {
#nullable disable
        var adminSession = JsonConvert.DeserializeObject<AdminPersonal>(HttpContext.Session.GetString("AdminSession"));
        employee.ModifiedBy = $"{adminSession.FirstName} {adminSession.LastName}";
#nullable enable
        employee.ModifiedDate = DateTime.Today;

        var result = await _employeeRepository.UpdateEmployeeByIdAsync(employee);
        return RedirectToAction("EmployeeList");
    }
}
