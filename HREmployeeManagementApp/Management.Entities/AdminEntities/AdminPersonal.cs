using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Entities.AdminEntities;
public class AdminPersonal
{
    public bool AdminStatus { get; set; }
    public int AdminID { get; set; }
    public int EmployeeID { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Designation { get; set; } = string.Empty;
    public DateTime AdminCreationDate { get; set; }
    public DateTime AdminTerminationDate { get; set; }
}
