using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Entities.AttendanceEntities;
public class LeavePersonal
{
    public int LeaveID { get; set; }

    [Required(ErrorMessage = "EmployeeID Not Found!")]
    public int EmployeeID { get; set; }

    [Required]
    public DateTime DateFrom { get; set; }

    [Required]
    public DateTime ToDate { get; set; }

    [Required]
    public DateTime DateOfRequest { get; set; }

    [Required]
    [MaxLength(300)]
    public string? Reason { get; set; }
    
    public bool ApprovalStatus { get; set; }

    [MaxLength(300)]
    public string? Comment { get; set; }
}
