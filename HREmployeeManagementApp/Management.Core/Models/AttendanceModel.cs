using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Core.Models;
public class AttendanceModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AttendanceID { get; set; }

    [Required(ErrorMessage = "EmployeeID Not Found!")]
    public int EmployeeID { get; set; }

    [Required(ErrorMessage = "First name is required", AllowEmptyStrings = false)]
    [MaxLength(50)]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required", AllowEmptyStrings = false)]
    [MaxLength(50)]
    public string? LastName { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public string? Status { get; set; }

    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }


    public DateTime CreatedOn { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public Guid ModifiedBy { get; set; }
}
