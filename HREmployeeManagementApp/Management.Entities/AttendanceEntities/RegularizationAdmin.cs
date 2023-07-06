using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Entities.AttendanceEntities;
public class RegularizationAdmin
{
	public int RegularizeID { get; set; }

	public int AttendanceID { get; set; }

	public int EmployeeID { get; set; }

	public DateTime RegularizeDate { get; set; }

	public TimeSpan CheckedIn { get; set; }

	public TimeSpan CheckedOut { get; set; }

	public DateTime DateOfRequest { get; set; }


	public TimeSpan AppliedCheckIn { get; set; }


	public TimeSpan AppliedCheckOut { get; set; }

	public string? Reason { get; set; }

	public string? RegularizedBy { get; set; }


	public bool Approved { get; set; }

	public string? Comment { get; set; }
}
