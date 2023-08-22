using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Entities.AttendanceEntities
{
    public class LeavePersonalApply
    {
        public int LeaveId { get; set; }

        [Required(ErrorMessage = "EmployeeID Not Found!")]
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "Please select a Leave Type.")]
        public string? LeaveType { get; set; }

       

        [Required]
        public DateTime DateFrom { get; set; }

        [Required]
        public DateTime ToDate { get; set; }
        public bool IsHalfDay { get; set; }
        [Required]

        [MaxLength(300)]
        public string? ReasonForLeave { get; set; }

        [Required]
        public double LeaveDays { get; set; }


    }
}
