﻿using Management.Application.Interfaces;
using Management.Entities.EmployeeEntities;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeHandler.Controllers;
public class LoginController : Controller
{

    public IActionResult Login()
    {
        var response = new EmployeeLogin();
        return View(response);
    }

    private readonly IEmployeeRepository _employeeRepository;
    public LoginController(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Login(EmployeeLogin employeeLogin)
    {
        var response = await _employeeRepository.CheckEmployeeAysnc(employeeLogin);


        if (response == 0)
        {
            // Credentials are invalid, return an error message or redirect to a login failure page
            TempData["Error"] = ("Credentials are invalid. Please try again.");
            return View();
                
        }
        else
        {
            // Credentials are valid, perform the desired action
            var url = Url.Action("PersonalDetails", "EmployeePersonal", new { EmployeeID = response });
            return Redirect(url);
            //return RedirectToAction("EmployeeDashboard", "EmployeeDashboard");            
        }
    }
}
