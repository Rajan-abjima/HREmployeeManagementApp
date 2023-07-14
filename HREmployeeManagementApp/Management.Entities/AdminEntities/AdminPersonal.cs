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
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Designation { get; set; }
    public DateTime AdminCreationDate { get; set; }
    public DateTime AdminTerminationDate { get; set; }
}
