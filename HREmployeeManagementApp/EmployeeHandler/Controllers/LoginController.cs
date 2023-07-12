using Management.Application.Interfaces;
using Management.Core.Models;
using Management.Entities.AdminEntities;
using Management.Entities.EmployeeEntities;
using Management.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace EmployeeHandler.Controllers;
public class LoginController : Controller
{
    private readonly IEmployeeRepository _employeeRepository;
    public LoginController(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public IActionResult Login()
    {
        var response = new LoginViewModel();
        return View(response);
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
            var employee = new EmployeePersonal() { EmployeeID = response};
            HttpContext.Session.SetString("EmployeeSession",JsonConvert.SerializeObject(employee));
            // Credentials are valid, perform the desired action
            var url = Url.Action("GetPersonalDetails", "EmployeePersonal", new { EmployeeID = response });
            /*Using assert to declare that "url" will never be null so Redirect doesnt show null warning*/
            Debug.Assert(url != null, "The generated URL should not be null.");
            return Redirect(url);
        }
    }

    public IActionResult AdminLogin()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> AdminLogin(AdminLogin adminLogin)
    {
        var response = await _employeeRepository.CheckAdminAsync(adminLogin);

        if (response is null)
        {
            // Credentials are invalid, return an error message or redirect to a login failure page
            TempData["AdminError"] = ("You are not an Administrator.");
            return View();
        }
        else
        {
            var profile = await _employeeRepository.GetAdminByIdAsync(response.EmployeeID, response.AdminID);
            //var admin = new AdminPersonal() { AdminID = profile.AdminID, EmployeeID = profile.EmployeeID, FirstName = profile.FirstName, LastName = profile.LastName};
            HttpContext.Session.SetString("AdminSession", JsonConvert.SerializeObject(profile));
            // Credentials are valid, perform the desired action
            //var url = Url.Action("AdminDashboard", "AdminDashboard", new { AdminID = response.AdminID, EmployeeID = response.EmployeeID });
            /*Using assert to declare that "url" will never be null so Redirect doesnt show null warning*/
            //Debug.Assert(url != null, "The generated URL should not be null.");
            return RedirectToAction("AdminDashboard", "AdminDashboard", new { AdminID = response.AdminID, EmployeeID = response.EmployeeID });
        }
    }
}
