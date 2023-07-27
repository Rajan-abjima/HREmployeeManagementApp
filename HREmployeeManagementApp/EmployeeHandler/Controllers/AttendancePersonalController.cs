using Management.Application.Interfaces;
using Management.Core.Models;
using Management.Entities.AttendanceEntities;
using Management.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeHandler.Controllers;
public class AttendancePersonalController : Controller
{
    private readonly IAttendanceRepository _attendanceRepository;

    public AttendancePersonalController(IAttendanceRepository attendanceRepository)
    {
        _attendanceRepository = attendanceRepository;
    }

    [HttpGet]
    public IActionResult Leave(int employeeID)
    {
        var response = new LeavePersonal();
        return View(response);
    }

    [HttpPost]
    public async Task<IActionResult> LeaveRequest(LeavePersonal leavePersonal)
    {
        leavePersonal.DateOfRequest = DateTime.Now;
        var leaveRequest = await _attendanceRepository.LeaveRequestAsync(leavePersonal);
        TempData["LeaveRequestID"] = leaveRequest.LeaveID;
        return RedirectToAction("Leave", new {EmployeeID = leaveRequest.EmployeeID, LeaveRequestID = leaveRequest.LeaveID});
    }

    [HttpGet]
    public async Task<IActionResult> RegularizeEntry(int attendanceID, int employeeID)
    {
        
        var record = await _attendanceRepository.GetAttendanceByAttendanceID(attendanceID);

        EmployeeRegularization newRecord = new()
        {
            AttendanceID = attendanceID,
            EmployeeID = employeeID,
            RegularizeDate = record.Date,
            CheckedIn = record.CheckIn,
            CheckedOut = record.CheckOut
        };
        return View(newRecord);
    }

    [HttpPost]
    public async Task<IActionResult> RegularizeRequest(EmployeeRegularization regularization)
    {
        var requestDetails = await _attendanceRepository.RegularizationRequestAsync(regularization);
        TempData["RegularizeRequest"] = requestDetails.RegularizeID;
        return RedirectToAction("GetPersonalDetails", "EmployeePersonal",
            new { EmployeeID  = requestDetails.EmployeeID, RegularizeID = requestDetails.RegularizeID});
    }


    [HttpGet]
    public async Task<IActionResult> AttendanceDetails(int employeeID)
    {
        var result = await _attendanceRepository.GetAttendancePersonalAsync(employeeID);

        AttendanceViewModel attendanceView = new AttendanceViewModel()
        {
            AttendanceList = result
        };

        TempData["EmployeeIDForAttendance"] = employeeID;
        return View(attendanceView);
    }

    [HttpGet]
    public async Task<IActionResult> FilterTablePartial (int employeeID)
    {
        var response = await _attendanceRepository.GetAttendancePersonalAsync(employeeID);
        
        return PartialView("_FullAttendanceList", response);
    }


    [HttpGet]
    public IActionResult RegularizationForm(int employeeID)
    {
        return View();
    }
}
