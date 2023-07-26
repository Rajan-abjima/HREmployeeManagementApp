//using Management.Entities.AttendanceEntities;
//using Management.Infrastructure.Repositories;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;

//namespace EmployeeHandler.Controllers
//{
//    public class LeaveController : Controller
//    {
//        private readonly ILeaveRepository _leaveRepository;
       

//        public LeaveController(ILeaveRepository leaveRepository)
//        {
//            _leaveRepository = leaveRepository;
            
//        }
//        public async Task<IActionResult> LeaveApply()
//        {
          
//            var leavesTypes = await _leaveRepository.GetLeavesTypes();
//            var selectList = new SelectList(leavesTypes, "LeaveTypeName", "LeaveTypeName");
//            TempData["LeaveType"] = selectList;

//            return View();
//        }



        // POST: Leave/ApplyLeave
        //[HttpPost]
        //public async Task<IActionResult> LeaveApply(Leave leave)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        await _leaveRepository.ApplyLeaveAsync(leave);
        //        //TempData["LeaveRequestID"] = leave.LeaveID; // Assuming LeaveID is returned by the ApplyLeaveAsync method
        //        return RedirectToAction("Leave", "Leave"); // Redirect to the Home page or any other success page
        //    }

        //    // If the model is not valid, retrieve the LeavesTypes again and return to the view with the model
        //    var leavesTypes = await _leaveRepository.GetLeavesTypes();
        //    TempData["LeaveType"] = leavesTypes;
        //    return View(leave);
        //}
//    }
//}
