using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Entities.AttendanceEntities;
public class EmployeeRegularization
{
	public int RegularizeID { get; set; }

	public int AttendanceID { get; set; }

	public int EmployeeID { get; set; }

	public DateTime RegularizeDate { get; set; }

	public DateTime CheckedIn { get; set; }

	public DateTime CheckedOut { get; set; }

	public DateTime DateOfRequest { get; set; }

    public DateTime AppliedCheckIn { get; set; }

    public DateTime AppliedCheckOut { get; set; }


    public string? Reason { get; set; }



	public TimeSpan CheckInTime { get; set; }
	public TimeSpan CheckOutTime { get; set; }
}