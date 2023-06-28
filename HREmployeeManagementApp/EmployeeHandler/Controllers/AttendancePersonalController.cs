using Management.Application.Interfaces;
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
