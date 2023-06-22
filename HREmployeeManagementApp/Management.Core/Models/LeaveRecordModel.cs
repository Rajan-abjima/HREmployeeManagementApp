using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Core.Models;
public class LeaveRecordModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int LeaveID { get; set; }

    [Required(ErrorMessage = "AttendanceID Not Found!")]
    public int AttendanceID { get; set; }

    [Required(ErrorMessage = "EmployeeID Not Found!")]
    public int EmployeeID { get; set; }

    [Required(ErrorMessage = "First name is required", AllowEmptyStrings = false)]
    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Last name is required", AllowEmptyStrings = false)]
    [MaxLength(50)]
    public string? LastName { get; set; }

    [Required]
    public DateTime DateFrom { get; set; }

    [Required]
    public DateTime ToDate { get; set; }

    [Required]
    public DateTime DateOfRequest { get; set; }

    [Required]
    [MaxLength(300)]
    public string? Reason { get; set; }

    [Required]
    public string? AdministeredBy { get; set; }

    [Required]
    public bool ApprovalStatus { get; set; }

    [MaxLength(300)]
    public string? Comment { get; set; }
}
