using Management.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeHandler.Controllers;
public class AttendanceAdminController : Controller
{
    private readonly IAttendanceRepository _attendanceRepository;

    public AttendanceAdminController(IAttendanceRepository attendanceRepository)
    {
        _attendanceRepository = attendanceRepository;
    }

    [HttpGet]
    public async Task<IActionResult> EmployeeAttendanceList(DateTime date)
    {
        date = DateTime.Today.AddDays(-1);
        var result = await _attendanceRepository.GetAttendanceAdminByDateAsync(date);
        return View(result);
    }
}
