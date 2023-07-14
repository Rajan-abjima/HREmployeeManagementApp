using Management.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Management.Entities.EmployeeEntities;
using Management.Entities.AttendanceEntities;
using Management.ViewModel;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Management.Entities.AdminEntities;

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
    public async Task<IActionResult> GetPersonalDetails(int employeeID)
    {
        //Getting the parameter from query string as string and converting it to employeeID which is Integer//        
        string? stringEmployeeID = HttpContext.Request.Query["EmployeeID"];
        int.TryParse(stringEmployeeID, out employeeID);
        /****************************************************************************************************/
#nullable disable
        var employeeSession = JsonConvert.DeserializeObject<EmployeePersonal>(HttpContext.Session.GetString("EmployeeSession"));
        PersonalDetails personalDetails = new()
        {
            EmployeePersonal = await _employeeRepository.GetByIdAsync(employeeSession.EmployeeID)
        };
#nullable enable
        return View(personalDetails);
    }

    [HttpGet]
    public async Task<IActionResult> CheckIn(int employeeID)
    {
        //string? stringemployeeID = HttpContext.Request.Query["EmployeeID"];
        //int.TryParse(stringemployeeID, out employeeID);

        var tempInfo = await _employeeRepository.GetByIdAsync(employeeID);
        DayCheckIn dayCheckIn = new DayCheckIn
        {
            EmployeeID = employeeID,
            FirstName = tempInfo.FirstName,
            LastName = tempInfo.LastName
        };


	    PersonalDetails personalDetails = new()
        {
            CheckIn = await _attendanceRepository.AddCheckInAsync(dayCheckIn),
            EmployeePersonal = await _employeeRepository.GetByIdAsync(employeeID)
        };
        TempData["AttendanceID"] = personalDetails.CheckIn.AttendanceID;
        
        return RedirectToAction("GetPersonalDetails", "EmployeePersonal", new { EmployeeId = employeeID, AttendanceID = personalDetails.CheckIn.AttendanceID });
        
	}

	[HttpGet]
    public async Task<IActionResult> CheckOut(int attendanceID, int employeeID)
    {
        DayCheckOut dayCheckOut = new DayCheckOut();
        dayCheckOut.AttendanceID = attendanceID;
        dayCheckOut.EmployeeID = employeeID;

        PersonalDetails personalDetails = new()
        {
            CheckOut = await _attendanceRepository.UpdateCheckOutAsync(dayCheckOut),
            EmployeePersonal = await _employeeRepository.GetByIdAsync(employeeID)
        };
		return RedirectToAction("GetPersonalDetails", "EmployeePersonal", new { EmployeeId = employeeID});
	}

    [HttpGet]
    public IActionResult Logout()
    {
        HttpContext.Session.Remove("EmployeeSession");
        return RedirectToAction("Login","Login");
    }


	public async Task<IActionResult> UpdatesLeaveRequestRecordPartial(int employeeID)
	{
#nullable disable
        var employeeSession = JsonConvert.DeserializeObject<EmployeePersonal>(HttpContext.Session.GetString("EmployeeSession"));
		employeeID = employeeSession.EmployeeID;
#nullable enable
        var response = await _attendanceRepository.GetAllLeaveRequestsByID(employeeID);
		return PartialView("_UpdatesLeaveRequestRecord", response);
	}
}