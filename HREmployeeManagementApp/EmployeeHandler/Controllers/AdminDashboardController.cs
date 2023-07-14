using Management.Application.Interfaces;
using Management.Entities.AdminEntities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EmployeeHandler.Controllers;
public class AdminDashboardController : Controller
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IAttendanceRepository _attendanceRepository;

    public AdminDashboardController(IEmployeeRepository employeeRepository,IAttendanceRepository attendanceRepository)
    {
        _employeeRepository = employeeRepository;
        _attendanceRepository = attendanceRepository;
    }

    public async Task<IActionResult> AdminDashboard(int EmployeeID, int AdminID)
    {
#nullable disable
        var adminSession = JsonConvert.DeserializeObject<AdminPersonal>(HttpContext.Session.GetString("AdminSession"));
        EmployeeID = adminSession.EmployeeID;
        AdminID = adminSession.AdminID;
#nullable enable
        var response = await _employeeRepository.GetAdminByIdAsync(EmployeeID,AdminID);
        return View(response);
    }

    public async Task<IActionResult> PendingLeaveRequestsPartial()
    {
        var response = await _attendanceRepository.PendingLeaveRequestAsync();
        return PartialView("_PendingLeaveRequests",response);
    }

    public async Task<IActionResult> PendingRegularizationRequestsPartial()
    {
        var response = await _attendanceRepository.PendingRegularizationRequestAsync();
        return PartialView("_PendingRegularizationRequests", response);
    }
}