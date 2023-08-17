using Management.Application.Interfaces;
using Management.Entities.AdminEntities;
using Management.Entities.EmployeeEntities;
using Management.ViewModel;
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

    public async Task<IActionResult> AdminDashboard(int EmployeeID)
    {
        var adminSession = JsonConvert.DeserializeObject<EmployeeAdmin>(HttpContext.Session.GetString("AdminSession"));
        EmployeeID = adminSession.EmployeeID;
        var AdminDetails = await _employeeRepository.GetEmployeeByIdAsync(EmployeeID);

        var PendingRegularizationList = await _attendanceRepository.PendingRegularizationRequestAsync();

        AdminDashboardViewModel viewModel = new AdminDashboardViewModel()
        {
            EmployeeAdmin = AdminDetails,
            PendingRegularizationRequests = PendingRegularizationList.ToList()
        };

        return View(viewModel);
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