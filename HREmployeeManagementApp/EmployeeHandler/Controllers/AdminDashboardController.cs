using Management.Application.Interfaces;
using Management.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace EmployeeHandler.Controllers;
public class AdminDashboardController : Controller
{
    private readonly IAttendanceRepository _attendanceRepository;

    public AdminDashboardController(IAttendanceRepository attendanceRepository)
    {
        _attendanceRepository = attendanceRepository;
    }

    public IActionResult AdminDashboard()
    {
        return View();
    }

    //public async Task<IActionResult> Ad()
    //{
    //    var response = await _attendanceRepository.PendingLeaveRequestAsync();

    //    RequestsViewModel requestsViewModel = new()
    //    {

    //    }
       
    //    return View();
    //}
}
