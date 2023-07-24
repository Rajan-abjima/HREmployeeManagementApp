namespace Management.Entities.EmployeeEntities;
public class EmployeePersonal
{
    public int EmployeeID { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string Address { get; set; } = string.Empty;
    public string Contact { get; set; } = string.Empty;
    public string Designation { get; set; } = string.Empty;
    public string SignInApprovedBy { get; set; } = string.Empty;
    public DateTime JoiningDate { get; set; }

    public DateTime ModifiedOn { get; set; }

    public Guid ModifiedBy { get; set; }
    public bool AdminStatus { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid CreatedBy { get; set; }
}

    