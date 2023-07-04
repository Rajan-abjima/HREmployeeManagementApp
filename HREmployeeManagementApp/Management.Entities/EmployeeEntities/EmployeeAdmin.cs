namespace Management.Entities.EmployeeEntities;
public class EmployeeAdmin
{
    public int EmployeeID { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string? LastName { get; set; }
    public string? Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? Address { get; set; }
    public string? Contact { get; set; }
    public string? Designation { get; set; }
    public string? SignInApprovedBy { get; set; }
    public DateTime JoiningDate { get; set; }

    public DateTime ModifiedDate { get; set; }
    public string? ModifiedBy { get; set; }

    public DateTime LeavingDate { get; set; }

    public bool AdminStatus { get; set; }
}