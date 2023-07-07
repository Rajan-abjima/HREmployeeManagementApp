using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Entities.AdminEntities;
public class AdminLogin
{
    public int ID { get; set; }
    public int EmployeeID { get; set; }
    public int AdminID { get; set; }
    public string? AdminPassword { get; set; }
}
