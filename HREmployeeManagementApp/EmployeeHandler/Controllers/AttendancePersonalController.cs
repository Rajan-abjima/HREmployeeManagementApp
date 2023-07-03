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

    [HttpGet]
    public IActionResult LeaveForm(int employeeID)
    {
        return View(employeeID);
    }

    [HttpGet]
    public IActionResult RegularizationForm()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> RegularizeRequest(EmployeeRegularization regularization)
    {
        RegularizeViewModel regularizeView = new RegularizeViewModel();
        regularization.EmployeeID = regularizeView.EmployeeRegularization.EmployeeID;
        var requestDetails = await _attendanceRepository.RegularizationRequestAsync(regularization);
        TempData["RegularizeRequest"] = requestDetails.RegularizeID;
        return RedirectToAction("GetPersonalDetails", "EmployeePersonal", 
            new { EmployeeID  = requestDetails.EmployeeID, RegularizeID = requestDetails.RegularizeID});
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
