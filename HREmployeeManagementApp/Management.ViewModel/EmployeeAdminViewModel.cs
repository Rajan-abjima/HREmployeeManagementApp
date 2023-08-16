using Management.Entities.AttendanceEntities;
using Management.Entities.EmployeeEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Management.ViewModel;
public class EmployeeAdminViewModel
{
    public int EmployeeID { get; set; }
    public IEnumerable<EmployeeAdmin> Employees { get; set; }
}
