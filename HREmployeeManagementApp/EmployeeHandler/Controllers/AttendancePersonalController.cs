using Management.Application.Interfaces;
using Management.Entities.AttendanceEntities;
using Management.Infrastructure.Repositories;
using Management.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static Management.Entities.AttendanceEntities.LeavePersonal;

namespace EmployeeHandler.Controllers;
public class AttendancePersonalController : Controller
{
    private readonly IAttendanceRepository _attendanceRepository;

    public AttendancePersonalController(IAttendanceRepository attendanceRepository)
    {
        _attendanceRepository = attendanceRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Leave(int employeeID)
    {

        var leavesTypes = await _attendanceRepository.GetLeavesTypes();

        LeavePersonalApply leaveView = new LeavePersonalApply()
        {
            LeaveType = leavesTypes.Select(a => a.LeaveTypeName)
        };
       
        return View(leaveView);

    }
    [HttpPost]
    public async Task<IActionResult> LeaveRequest(LeavePersonalApply model)
    {
        if (ModelState.IsValid)
        {
            
            int leaveDaysExcludingWeekends = CalculateLeaveDaysExcludingWeekends(model.DateFrom, model.ToDate);

            
            model.LeaveDays = leaveDaysExcludingWeekends;

            
            var leaveRequestId = await _attendanceRepository.ApplyLeave(model);
            TempData["LeaveRequestId"] = leaveRequestId;

            // Redirect to the "Success" action, passing the leaveRequestId as a parameter
            return RedirectToAction("Success", new { id = leaveRequestId });

        }

        
        return View("~/Views/AttendancePersonal/Leave.cshtml", model);
    }

    private int CalculateLeaveDaysExcludingWeekends(DateTime startDate, DateTime endDate)
    {
        int totalLeaveDays = (int)(endDate - startDate).TotalDays + 1;
        int excludeWeekends = 0;

        for (int i = 0; i < totalLeaveDays; i++)
        {
            DateTime currentDate = startDate.AddDays(i);
            if (currentDate.DayOfWeek == DayOfWeek.Saturday || currentDate.DayOfWeek == DayOfWeek.Sunday)
            {
                excludeWeekends++;
            }
        }

        return totalLeaveDays - excludeWeekends;
    }
    //[HttpPost]
    //public async Task<IActionResult> LeaveRequest(LeavePersonal leavePersonal)
    //{
    //    leavePersonal.DateOfRequest = DateTime.Now;

    //    var leaveRequest = await _attendanceRepository.LeaveRequestAsync(leavePersonal);
    //    TempData["LeaveRequestID"] = leaveRequest.LeaveID;
    //    return RedirectToAction("Leave", new {EmployeeID = leaveRequest.EmployeeID, LeaveRequestID = leaveRequest.LeaveID});
    //}

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
