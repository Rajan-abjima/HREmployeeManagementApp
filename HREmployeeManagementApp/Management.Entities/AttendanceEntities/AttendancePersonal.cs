using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Entities.AttendanceEntities;
public class AttendancePersonal
{
	public int AttendanceID { get; set; }

	public int EmployeeID { get; set; }

	public DateTime Date { get; set; }

	public string? Status { get; set; }

	public DateTime CheckIn { get; set; }
	public DateTime CheckOut { get; set; }

    public Guid? ModifiedBy { get; set; }

	public bool IsRegularised { get; set; }
}
