using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Entities.AttendanceEntities;
public class DayCheckIn
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AttendanceID { get; set; }

    [Required(ErrorMessage = "EmployeeID Not Found!")]
    public int EmployeeID { get; set; }

    [Required]
    public string? FirstName { get; set; }
    
    [Required]
    public string? LastName { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public string? Status { get; set; }

    [Required]
    public TimeSpan CheckIn { get; set; }
}
