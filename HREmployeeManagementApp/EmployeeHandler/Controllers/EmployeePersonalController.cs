using Management.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using Management.Entities.EmployeeEntities;
using Management.Infrastructure.Repositories;

namespace EmployeeHandler.Controllers;

public class EmployeePersonalController : Controller
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IEmployeeDashboardRepository _employeeDashboardRepository;

    public EmployeePersonalController(IEmployeeRepository employeeRepository,
                                      IEmployeeDashboardRepository employeeDashboardRepository)
    {
        _employeeRepository = employeeRepository;
        _employeeDashboardRepository = employeeDashboardRepository;
    }

    public IActionResult EmployeeRegistration()
    {
        var response = new EmployeePersonal();
        return View(response);
    }
     

    [HttpPost]
    public async Task<IActionResult> EmployeeRegistration(EmployeePersonal employee)
    {
        var employeeData = await _employeeRepository.AddAsync(employee);
        TempData["Success"] = employeeData.EmployeeID;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SignUpCredentials(EmployeeSignUp employee)
    {
        var employeeData = await _employeeRepository.AddCredentialsAsync(employee);
        TempData["SignUpSuccess"] = "Your Sign Up was successful";
        return RedirectToAction("Login","Login");
    }

    public IActionResult PersonalDetails ()
    {
        var response = new EmployeePersonal();
        return View(response);
    }

    public async Task<IActionResult> PersonalDetails(int employeeID)
    {
        var employeeData = await _employeeDashboardRepository.GetByIDAsync(employeeID);
        return View();
    }
}