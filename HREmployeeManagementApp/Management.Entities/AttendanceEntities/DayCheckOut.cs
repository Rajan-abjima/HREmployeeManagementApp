using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Entities.AttendanceEntities;
public class DayCheckOut

{
    [Required]
    public int AttendanceID { get; set; }

    [Required]
    public int EmployeeID { get; set;}
    
    [Required]
    public TimeSpan CheckOut { get; set; }

}
