using Management.Entities.AttendanceEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Interfaces;
public interface IAttendanceRepository
{
    Task<DayCheckIn> AddCheckInAsync(DayCheckIn checkInToday);
    Task<DayCheckOut> UpdateCheckOutAsync(DayCheckOut checkOutToday);
    Task<AttendancePersonal> GetExactAttendanceByEmployeeIDAsync(int employeeID);
    Task<IReadOnlyList<AttendancePersonal>> GetAttendancePersonalAsync(int employeeID);
    Task<IEnumerable<AttendanceAdmin>> GetAttendanceAdminByIDAndDateAsync (int employeeId, DateTime date);
    Task<IEnumerable<AttendanceAdmin>> GetAttendanceAdminByIDAsync(int employeeID);
    Task<EmployeeRegularization> RegularizationRequestAsync (EmployeeRegularization regularization);

    Task<IReadOnlyList<LeavePersonal>> GetAllLeaveRequestsByID(int employeeID);
    Task<LeavePersonal> LeaveRequestAsync(LeavePersonal leave);

    Task<IReadOnlyList<LeaveAdmin>> PendingLeaveRequestAsync();
    Task<IReadOnlyList<RegularizationAdmin>> PendingRegularizationRequestAsync();

    Task<IEnumerable<LeaveAdmin>> GetAllLeavesAsync();
    Task<LeaveAdmin> GetLeaveByID(int leaveID);
    Task<int> UpdateLeaveRequest(LeaveAdmin leaveAdmin);

    Task<IEnumerable<RegularizationAdmin>> GetAllRegularizationsAsync();
    Task<RegularizationAdmin> GetRegualrizationByID(int regularizeID);
    Task<int> UpdateRegularizationRequest(RegularizationAdmin regularizationAdmin);
}