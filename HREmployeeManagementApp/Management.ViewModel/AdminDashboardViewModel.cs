﻿using Management.Entities.AttendanceEntities;
using Management.Entities.EmployeeEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.ViewModel;
public class AdminDashboardViewModel
{
    public EmployeeAdmin EmployeeAdmin = new EmployeeAdmin();
    public RegularizationAdmin RegularizationAdmin = new RegularizationAdmin();
    public List<RegularizationAdmin> PendingRegularizationRequests = new List<RegularizationAdmin>();
    public List<LeaveAdmin> PendingLeaveRequests = new List<LeaveAdmin>();
}
