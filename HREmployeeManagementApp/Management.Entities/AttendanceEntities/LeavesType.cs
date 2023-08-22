using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Entities.AttendanceEntities
{
    public class LeavesType
    {
        public int LeaveTypeId { get; set; }

        [Required(ErrorMessage = "Please select a Leave Type.")]
        public string? LeaveType { get; set; }

        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int ModifiedBy { get; set; }
    }
}
