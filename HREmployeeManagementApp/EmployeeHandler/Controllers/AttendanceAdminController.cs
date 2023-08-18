using Management.Application.Interfaces;
using Management.Entities.AttendanceEntities;
using Management.Entities.EmployeeEntities;
using Management.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EmployeeHandler.Controllers;
public class AttendanceAdminController : Controller
{
    private readonly IAttendanceRepository _attendanceRepository;
    private readonly IEmployeeRepository _employeeRepository;

    public AttendanceAdminController(IAttendanceRepository attendanceRepository, IEmployeeRepository employeeRepository)
    {
        _attendanceRepository = attendanceRepository;
        _employeeRepository = employeeRepository;
    }

    [HttpGet]
    public async Task<IActionResult> EmployeeAttendanceList(int employeeID)
    {
        var details = await _employeeRepository.GetEmployeeByIdAsync(employeeID);

        AttendanceViewModel viewModel = new()
        {
            EmployeeID = employeeID,
            EmployeeDetails = details
        };
        return View(viewModel);
    }
    
    [HttpGet]
    public async Task<IActionResult> EmployeeAttendanceListPartial(int employeeID)
    {
        var result = await _attendanceRepository.GetAttendanceAdminByIDAsync(employeeID);

        AttendanceViewModel viewModel = new()
        {
            EmployeeID = employeeID,
            EmployeeAttendanceList = result.ToList()
        };
        return Json(result.ToList());
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
        var adminSession = JsonConvert.DeserializeObject<EmployeeAdmin>(HttpContext.Session.GetString("AdminSession"));
        leaveAdmin.AdministeredBy = $"{adminSession.FirstName} {adminSession.LastName}";
        var response = await _attendanceRepository.UpdateLeaveRequest(leaveAdmin);


        return RedirectToAction("AdminDashboard", "AdminDashboard", new {EmployeeID = adminSession.EmployeeID});
    }

    [HttpGet]
    public async Task<IActionResult> CheckRegularizationRequest(int regularizeID)
    {
        var response = await _attendanceRepository.GetRegualrizationByID(regularizeID);
        return Json(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> ConfirmRegularizationRequest(RegularizationAdmin regularizationAdmin)
    {
        //if (regularizationAdmin.Approved !=true )
        //{
        //    regularizationAdmin.Approved = false;
        //}

        var adminSession = JsonConvert.DeserializeObject<EmployeeAdmin>(HttpContext.Session.GetString("AdminSession"));
        regularizationAdmin.RegularizedBy = adminSession.Identifier;
        var response = await _attendanceRepository.UpdateRegularizationRequest(regularizationAdmin);


        return RedirectToAction("AdminDashboard", "AdminDashboard", new {EmployeeID = adminSession.EmployeeID});
    }


}
