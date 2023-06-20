using Management.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using Management.Entities.EmployeeEntities;
using Management.Infrastructure.Repositories;
using Management.Core.Models;
using Management.Mapping.Profiles;

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

    [HttpGet]
    public IActionResult EmployeeRegistration()
    {
        var response = new EmployeePersonal();
        return View(response);
    }
    
  
    [HttpPost]
    public async Task<IActionResult> EmployeeRegistration(EmployeePersonal employee)
    {
        var employeeData = await _employeeRepository.AddAsync(employee);
        
        return RedirectToAction("SignUpCredentials", "EmployeePersonal",new { employeeData.EmployeeID,employeeData.FirstName, employeeData.LastName});
    }
    
    [HttpGet]
    public IActionResult SignUpCredentials(int employeeID, string firstName, string lastName)
    {
        
        var response = new EmployeeSignUp()
        {
            EmployeeID = employeeID,
            FirstName = firstName,
            LastName = lastName,
            IsValid = true
        };
        TempData["Success"] = response.EmployeeID;
        return View(response);
    }

    [HttpPost]
    public async Task<IActionResult> SignUpCredentials(EmployeeSignUp employee)
    {
        var employeeData = await _employeeRepository.AddCredentialsAsync(employee);
        TempData["SignUpSuccess"] = $"User: {employeeData.UserName} - Your Sign Up was successful";
        return RedirectToAction("Login","Login");
    }

    [HttpGet]
    public async Task<IActionResult> PersonalDetails(int employeeID)
    {
        //Getting the parameter from query string as string and converting it to employeeID which is Integer//
        string stringEmployeeID = HttpContext.Request.Query["EmployeeID"];
        int.TryParse(stringEmployeeID, out employeeID);
        /**************************************************************************************************/

        var employeeData = await _employeeDashboardRepository.GetByIDAsync(employeeID);
        return View(employeeData);
    }
}