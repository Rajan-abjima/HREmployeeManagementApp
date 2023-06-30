using Management.Application.Interfaces;
using Management.Entities.AttendanceEntities;
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

    public IActionResult LeaveForm(int employeeID)
    {
        return View(employeeID);
    }

    [HttpGet]
    public /*async Task<IActionResult>*/ IActionResult RegularizationForm(int employeeID, int attendanceID)
    {
        //var response = await _attendanceRepository.GetExactAttendanceByEmployeeIDAsync(employeeID);
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> RegularizeRequest(EmployeeRegularization regularization)
    {
        var result = await _attendanceRepository.RegularizationRequestAsync(regularization);
        return View();
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
