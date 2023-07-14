using Management.Application.Interfaces;
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
    public IActionResult RegularizationForm()
    {
        return View();
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
        //Getting the parameter from query string as string and converting it to employeeID which is Integer//        
        string? stringEmployeeID = HttpContext.Request.Query["EmployeeID"];
        int.TryParse(stringEmployeeID, out employeeID);
        /****************************************************************************************************/

        var result = await _attendanceRepository.GetAttendancePersonalAsync(employeeID);

        return View(result);
    }
}
