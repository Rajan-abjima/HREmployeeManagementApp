using Management.Entities.Common;
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

	public DateTime CheckedIn { get; set; }

	public DateTime CheckedOut { get; set; }

	public DateTime DateOfRequest { get; set; }


	public DateTime AppliedCheckIn { get; set; }


	public DateTime AppliedCheckOut { get; set; }

	public string? Reason { get; set; }

	public Guid RegularizedBy { get; set; }

	public int Decision { get; set; }

	public string? Comment { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public Guid ModifiedBy { get; set; }

	public TimeSpan CheckInTime { get; set; }
	public TimeSpan CheckOutTime { get; set; }
}
