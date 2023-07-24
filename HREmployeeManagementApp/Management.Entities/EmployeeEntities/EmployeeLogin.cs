using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Management.Entities.EmployeeEntities;
public class EmployeeLogin
{
    [Required]
    public string UserName { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
}
