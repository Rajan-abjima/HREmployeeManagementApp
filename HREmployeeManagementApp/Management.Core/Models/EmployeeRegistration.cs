using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Management.Core.Models;
public partial class EmployeeRegistration
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    [Required]
    public int EmployeeID { get; set; }

    [Required(ErrorMessage = "First name required", AllowEmptyStrings = false)]
    public string FirstName { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "First name required", AllowEmptyStrings = false)]
    public string? LastName { get; set; }

    [Required(ErrorMessage = "Username required", AllowEmptyStrings = false)]
    public string? Username { get; set; }

    [Required(ErrorMessage = "Password required", AllowEmptyStrings = false)]
    [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
    public string? Password { get; set; }

    [Required]
    public bool IsValid { get; set; }
}