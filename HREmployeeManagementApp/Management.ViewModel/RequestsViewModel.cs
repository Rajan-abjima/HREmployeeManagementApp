using Management.Entities.AttendanceEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.ViewModel;
public class RequestsViewModel
{
    public LeaveAdmin? DateFrom { get; }
    public LeaveAdmin? ToDate { get;}
    public LeaveAdmin? Reason { get; }

}
