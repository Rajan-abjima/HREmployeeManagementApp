using Management.Application.Interfaces;
using Management.Enities.EmployeeEntities;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeHandler.Controllers;

public class EmployeePersonalController : Controller
{
    public IActionResult SignInForm()
    {
        return View();
    }

    private readonly IEmployeeRepository _employeeRepository;

    public EmployeePersonalController(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }



    [HttpPost]
    public async Task<IActionResult> SignUpForm(EmployeePersonal employee)
    {
        var employeeData = await _employeeRepository.AddAsync(employee);
        return View(employeeData);
    }
}