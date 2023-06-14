using Management.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using Management.Entities.EmployeeEntities;

namespace EmployeeHandler.Controllers;

public class EmployeePersonalController : Controller
{
    public IActionResult EmployeeRegistration()
    {
        var response = new EmployeePersonal();
        return View(response);
    }
     
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeePersonalController(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
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
}