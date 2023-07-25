using Management.Entities.AttendanceEntities;
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
    public DateTime DateFrom { get; set; } = DateTime.Today.AddDays(-30);
    public DateTime DateTo { get; set; } = DateTime.Today;

    public List<AttendancePersonal> AttendanceList { get; set; }

    public List<AttendancePersonal> FilteredListbyDate { get; set; }
    public AttendanceViewModel()
	{
		AttendanceList = new List<AttendancePersonal>();
        FilteredListbyDate = new List<AttendancePersonal>(AttendanceList.Where(x => x.Date < DateFrom && x.Date > DateTo ));
	}
}
