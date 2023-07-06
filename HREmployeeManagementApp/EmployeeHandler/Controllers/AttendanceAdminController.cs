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
    public async Task<IActionResult> EmployeeAttendanceList(int employeeID, DateTime date)
    {
        date = DateTime.Today;
        var result = await _attendanceRepository.GetAttendanceAdminByIDAndDateAsync(employeeID, date);
        return View(result);
    }
}
