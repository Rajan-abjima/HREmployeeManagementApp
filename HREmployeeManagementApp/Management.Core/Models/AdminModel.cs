using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Core.Models;
public class AdminModel
{
    [Required]
    public bool AdminStatus { get; set; }
    [Required]
    public int AdminID { get; set; }

    [Required] 
    public int EmployeeID { get; set; }
    [Required]
    public string? FirstName { get; set; }
    [Required]
    public string? LastName { get; set; }
    [Required]
    public string? Designation { get; set; }
    [Required]
    public DateTime AdminCreationDate { get; set; }
    public DateTime AdminTerminationDate { get; set; }
}
