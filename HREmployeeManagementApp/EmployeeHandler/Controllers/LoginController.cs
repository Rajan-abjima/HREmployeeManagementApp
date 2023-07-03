using Management.Application.Interfaces;
using Management.Entities.EmployeeEntities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

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
            var employee = new EmployeePersonal() { EmployeeID = response};
            HttpContext.Session.SetString("EmployeeSession",JsonConvert.SerializeObject(employee));
            // Credentials are valid, perform the desired action
            var url = Url.Action("GetPersonalDetails", "EmployeePersonal", new { EmployeeID = response });
            /*Using assert to declare that "url" will never be null so Redirect doesnt show null warning*/
            Debug.Assert(url != null, "The generated URL should not be null.");
            return Redirect(url);
        }
    }
}
