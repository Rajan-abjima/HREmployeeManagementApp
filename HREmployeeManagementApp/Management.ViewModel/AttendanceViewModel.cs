using Management.Entities.AttendanceEntities;
using Management.Entities.EmployeeEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Management.ViewModel;
public class AttendanceViewModel
{
    public int EmployeeID { get; set; }
    public EmployeeAdmin EmployeeDetails { get; set; }
    public IEnumerable<AttendancePersonal> AttendanceList { get; set; }
    public IEnumerable<AttendanceAdmin> EmployeeAttendanceList { get; set; }

    public EmployeeRegularization regularization = new EmployeeRegularization();
}
