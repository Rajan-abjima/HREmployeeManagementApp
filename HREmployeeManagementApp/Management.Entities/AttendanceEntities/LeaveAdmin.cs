using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Entities.AttendanceEntities;
public class LeaveAdmin
{
    public int LeaveID { get; set; }

    public int EmployeeID { get; set; }

    public DateTime DateFrom { get; set; }

    public DateTime ToDate { get; set; }

    public DateTime DateOfRequest { get; set; }

    public string? Reason { get; set; }

    public string? AdministeredBy { get; set; }

    public bool ApprovalStatus { get; set; }

    public string? Comment { get; set; }
}
