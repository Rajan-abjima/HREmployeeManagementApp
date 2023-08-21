using Management.Application.Interfaces;
using Management.Entities.AdminEntities;
using Management.Entities.EmployeeEntities;
using Management.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace EmployeeHandler.Controllers;
public class EmployeeAdminController : Controller
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeAdminController(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<IActionResult> EmployeeList()
    {
        try
        {
            var result = await _employeeRepository.GetAllEmployeesAsync();
            EmployeeAdminViewModel viewModel = new();
            return View(viewModel);
        }
        catch (Exception ex)
        {
			if (ex is ArgumentNullException)
			{
				return RedirectToAction("Login", "Login");
			}
			else
			{
				throw ex;
			}
		}
    }

    [HttpGet]
    public async Task<IActionResult> EmployeeListPartial()
    {
        var result = await _employeeRepository.GetAllEmployeesAsync();

        return Json(result.ToList());
    }



    [HttpGet]
    public async Task<IActionResult> EmployeeDetailsUpdate(int EmployeeID)
    {
        try
        {
            var employeeData = await _employeeRepository.GetEmployeeByIdAsync(EmployeeID);
            return View(employeeData);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    [HttpPost]
    public async Task<IActionResult> EmployeeDetailsUpdate(EmployeeAdmin employee)
    {
        var adminSession = JsonConvert.DeserializeObject<AdminPersonal>(HttpContext.Session.GetString("AdminSession"));
        var admindata = await _employeeRepository.GetEmployeeByIdAsync(adminSession.EmployeeID);
        employee.ModifiedBy = admindata.Identifier;
        employee.ModifiedOn = DateTime.Today;

        var result = await _employeeRepository.UpdateEmployeeByIdAsync(employee);
        return RedirectToAction("EmployeeList");
    }
}
