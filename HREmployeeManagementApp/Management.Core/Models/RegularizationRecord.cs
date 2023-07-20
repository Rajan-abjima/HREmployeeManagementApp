using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Core.Models;
public class RegularizationRecord
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RegularizeID { get; set; }

    [Required(ErrorMessage = "AttendanceID Not Found!")]
    public int AttendanceID { get; set; }

    [Required(ErrorMessage = "EmployeeID Not Found!")]
    public int EmployeeID { get; set; }

    [Required]
    public DateTime RegularizeDate { get; set; }
    
    [Required]
    public DateTime CheckedIn { get; set; }

    [Required]
    public DateTime CheckedOut { get; set; }

    [Required]
    public DateTime DateOfRequest { get; set; }

    
    public DateTime  AppliedCheckIn { get; set; }

    
    public DateTime AppliedCheckOut { get; set; }

    [Required(ErrorMessage = "You must state a reason for requesting regularization", AllowEmptyStrings = false)]
    [MaxLength(300)]
    public string? Reason { get; set; }

    
    [MaxLength(50)]
    public string? RegularizedBy { get; set; }

    
    public bool Approved { get; set; }

    [MaxLength(300)]
    public string? Comment { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public Guid ModifiedBy { get; set; }
}
