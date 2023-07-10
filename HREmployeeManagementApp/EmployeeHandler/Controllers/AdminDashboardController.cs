using Management.Application.Interfaces;
using Management.Entities.AdminEntities;
using Management.Entities.EmployeeEntities;
using Management.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Runtime.InteropServices;

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
        var employeeSession = JsonConvert.DeserializeObject<AdminPersonal>(HttpContext.Session.GetString("AdminSession"));
        EmployeeID = employeeSession.EmployeeID;
        AdminID = employeeSession.AdminID;
        var response = await _employeeRepository.GetAdminById(EmployeeID,AdminID);
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
