using Management.Application.Interfaces;
using Management.Enities.EmployeeEntities;
using Management.Entities.EmployeeEntities;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeHandler.Controllers;

public class EmployeePersonalController : Controller
{
    public IActionResult EmployeeRegistration()
    {
        var response = new EmployeePersonal();
        return View(response);
    }
     public IActionResult Login()
    {
        var response = new EmployeeLogin();
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
        return View(employeeData);
    }


    [HttpPost]
    public async Task<IActionResult> Login(EmployeeLogin employeelogin)
    {
        if(!ModelState.IsValid) return View(employeelogin);
    }
}