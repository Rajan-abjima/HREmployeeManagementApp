using Management.Application.Interfaces;
using Management.Enities.EmployeeEntities;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

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
        return View(employeeData);
    }

}