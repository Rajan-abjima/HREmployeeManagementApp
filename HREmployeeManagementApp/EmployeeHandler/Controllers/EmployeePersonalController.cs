using Management.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Management.Entities.EmployeeEntities;
using Management.Entities.AttendanceEntities;
using Management.ViewModel;

namespace EmployeeHandler.Controllers;

public class EmployeePersonalController : Controller
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IAttendanceRepository _attendanceRepository;

    public EmployeePersonalController(IEmployeeRepository employeeRepository,
                                      IAttendanceRepository attendanceRepository)
    {
        _employeeRepository = employeeRepository;
        _attendanceRepository = attendanceRepository;
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
        string? stringEmployeeID = HttpContext.Request.Query["EmployeeID"];
        int.TryParse(stringEmployeeID, out employeeID);
        /****************************************************************************************************/
        
        PersonalDetails personalDetails = new()
        {
            EmployeePersonal = await _employeeRepository.GetByIdAsync(employeeID)
        };
        return View(personalDetails);
    }

    [HttpPost]
    public async Task<IActionResult> CheckIn(DayCheckIn dayCheckIn, int employeeID)
    {
        var tempInfo = await _employeeRepository.GetByIdAsync(employeeID);
        
        
        PersonalDetails personalDetail = new()
        {
            CheckIn = await _attendanceRepository.AddCheckInAsync(dayCheckIn)
        };
        TempData["AttendanceID"] = personalDetail.CheckIn.AttendanceID;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CheckOut(DayCheckOut dayCheckOut)
    {
        var checkOutData = await _attendanceRepository.UpdateCheckOutAsync(dayCheckOut);
        return View();
    }
}