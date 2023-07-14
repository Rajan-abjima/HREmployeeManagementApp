using Management.Application.Interfaces;
using Management.Entities.AdminEntities;
using Management.Entities.AttendanceEntities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

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
    public async Task<IActionResult> LeaveRecord()
    {
        var response = await _attendanceRepository.GetAllLeavesAsync();
        return View(response);
    }


    [HttpGet]
    public async Task<IActionResult> RegularizationRecord()
    {
        var response = await _attendanceRepository.GetAllRegularizationsAsync();
        return View(response);
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
        if (leaveAdmin.ApprovalStatus != true)
        {
            leaveAdmin.ApprovalStatus = false;
        }
#nullable disable
        var adminSession = JsonConvert.DeserializeObject<AdminPersonal>(HttpContext.Session.GetString("AdminSession"));
        leaveAdmin.AdministeredBy = $"{adminSession.FirstName} {adminSession.LastName}";
#nullable enable
        var response = await _attendanceRepository.UpdateLeaveRequest(leaveAdmin);


        return RedirectToAction("AdminDashboard", "AdminDashboard", new {AdminID = adminSession.AdminID, EmployeeID = adminSession.EmployeeID});
    }

    [HttpGet]
    public async Task<IActionResult> CheckRegularizationRequest(int regularizeID)
    {
        var response = await _attendanceRepository.GetRegualrizationByID(regularizeID);
        return View(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> ConfirmRegularizationRequest(RegularizationAdmin regularizationAdmin)
    {
        if (regularizationAdmin.Approved != true)
        {
            regularizationAdmin.Approved = false;
        }
#nullable disable
        var adminSession = JsonConvert.DeserializeObject<AdminPersonal>(HttpContext.Session.GetString("AdminSession"));
        regularizationAdmin.RegularizedBy = $"{adminSession.FirstName} {adminSession.LastName}";
#nullable enable
        var response = await _attendanceRepository.UpdateRegularizationRequest(regularizationAdmin);


        return RedirectToAction("AdminDashboard", "AdminDashboard", new {AdminID = adminSession.AdminID, EmployeeID = adminSession.EmployeeID});
    }


}
