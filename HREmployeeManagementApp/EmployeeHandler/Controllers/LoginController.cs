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
    public async Task<IActionResult> Login(string Username, string Password, string LoginType)
    {

        try
        {
            EmployeeLogin employeeLogin = new EmployeeLogin()
            {
                Username = Username,
                Password = Password
            };
            var response = await _employeeRepository.CheckEmployeeAysnc(employeeLogin);


            if (response == 0)
            {
                // Credentials are invalid, return an error message or redirect to a login failure page
                TempData["Error"] = ("Credentials are invalid. Please try again.");
                return View();

            }
                // Credentials are valid, perform the desired action
            else
            {
                var employeeData = await _employeeRepository.GetEmployeeByIdAsync(response);
                switch (LoginType)
                {
                    case "Employee":
                        HttpContext.Session.SetString("EmployeeSession", JsonConvert.SerializeObject(employeeData));
                        return RedirectToAction("GetPersonalDetails", "EmployeePersonal", new { EmployeeID = response });

                    case "Admin":
                        if (employeeData.AdminStatus == true) 
                        {
                            HttpContext.Session.SetString("AdminSession", JsonConvert.SerializeObject(employeeData));
                            return RedirectToAction("AdminDashboard", "AdminDashboard", new { EmployeeID = response });
                        }
                        else
                        {
                            //TempData["NotAdmin"] = ($"{employeeData.FirstName} {employeeData.LastName}, You are not an Admin, Please choose employee login type");
                            //return View();
                            goto default;
                        }
                    default:
                        TempData["NotAdmin"] = ($"{employeeData.FirstName} {employeeData.LastName}, You are not an Admin, Please choose employee login type");
                        return View();
                }
            }


            //else if (LoginType == "Employee" && response != 0)
            //    {
            //        var employeeData = await _employeeRepository.GetByIdAsync(response);
            //        HttpContext.Session.SetString("EmployeeSession", JsonConvert.SerializeObject(employeeData));
            //        return RedirectToAction("GetPersonalDetails", "EmployeePersonal", new { EmployeeID = response });
            //    }
            //else if (LoginType == "Admin" && response != 0)
            //{
            //    var employeeData = await _employeeRepository.GetEmployeeByIdAsync(response);

            //    if (employeeData.AdminStatus == true)
            //    {
            //        HttpContext.Session.SetString("AdminSession", JsonConvert.SerializeObject(employeeData));
            //        return RedirectToAction("AdminDashboard", "AdminDashboard", new { EmployeeID = response});
            //    }
            //    else
            //    {
            //        TempData["NotAdmin"] = ($"{employeeData.FirstName} {employeeData.LastName}, You're are not an Admin");
            //        return View();
            //    }
            //}
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    //public IActionResult AdminLogin()
    //{
    //    return View();
    //}


    //[HttpPost]
    //public async Task<IActionResult> AdminLogin(AdminLogin adminLogin)
    //{
    //    try
    //    {
    //        var response = await _employeeRepository.CheckAdminAsync(adminLogin);

    //        if (response is null)
    //        {
    //            // Credentials are invalid, return an error message or redirect to a login failure page
    //            TempData["AdminError"] = ("You are not an Administrator.");
    //            return View();
    //        }
    //        else
    //        {
    //            var profile = await _employeeRepository.GetAdminByIdAsync(response.EmployeeID, response.AdminID);
    //            HttpContext.Session.SetString("AdminSession", JsonConvert.SerializeObject(profile));
    //            return RedirectToAction("AdminDashboard", "AdminDashboard", new { AdminID = response.AdminID, EmployeeID = response.EmployeeID });
    //        }
    //    }
    //    catch (Exception ex)
    //    {

    //        throw ex;
    //    }
    //}
}
