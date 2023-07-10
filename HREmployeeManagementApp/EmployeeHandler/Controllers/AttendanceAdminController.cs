using Management.Application.Interfaces;
using Management.Entities.AdminEntities;
using Management.Entities.AttendanceEntities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EmployeeHandler.Controllers;
public class AttendanceAdminController : Controller
{
    private readonly IAttendanceRepository _attendanceRepository;

    public AttendanceAdminController(IAttendanceRepository attendanceRepository)
    {
        _attendanceRepository = attendanceRepository;
    }

    [HttpGet]
    public async Task<IActionResult> EmployeeAttendanceList(int employeeID, DateTime date)
    {
        date = DateTime.Today;
        var result = await _attendanceRepository.GetAttendanceAdminByIDAndDateAsync(employeeID, date);
        return View(result);
    }

    [HttpGet]
    public async Task<IActionResult> CheckLeaveRequest(int leaveID)
    {
        var response = await _attendanceRepository.GetLeaveByID(leaveID);
        return View(response);
    }

    [HttpPost]
    public async Task<IActionResult> ConfirmLeaveRequest(LeaveAdmin leaveAdmin)
    {
        var adminSession = JsonConvert.DeserializeObject<AdminPersonal>(HttpContext.Session.GetString("AdminSession"));
        leaveAdmin.AdministeredBy = $"{adminSession.FirstName} {adminSession.LastName}";
        var response = await _attendanceRepository.UpdateLeaveRequest(leaveAdmin);


        return RedirectToAction("AdminDashboard", "AdminDashboard", new {AdminID = adminSession.AdminID, EmployeeID = adminSession.EmployeeID});
    }
}
