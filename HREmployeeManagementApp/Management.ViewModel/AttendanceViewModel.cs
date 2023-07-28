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
    public DateTime DateFrom { get; set; } 
    public DateTime DateTo { get; set; } 

    public string Status { get; set; } = string.Empty;

    public IEnumerable<AttendancePersonal> AttendanceList { get; set; }

 //   public List<AttendancePersonal> FilteredListbyDate { get; set; }
 //   public AttendanceViewModel()
	//{
 //       FilteredListbyDate = new List<AttendancePersonal>(AttendanceList.Where(x => x.Date < DateFrom && x.Date > DateTo ));
	//}
}
