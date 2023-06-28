﻿using Management.Entities.AttendanceEntities;
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
    Task<IEnumerable<AttendanceAdmin>> GetAttendanceAdminByIDAsync(int employeeID);
}