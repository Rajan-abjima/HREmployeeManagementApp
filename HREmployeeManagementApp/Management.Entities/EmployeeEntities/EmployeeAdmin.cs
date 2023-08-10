namespace Management.Entities.EmployeeEntities;
public class EmployeeAdmin
{
    public int EmployeeID { get; set; }
    public Guid Identifier { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string? LastName { get; set; }
    public string? Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? PresentAddress { get; set; }
    public string? MobileNumber { get; set; }
    public string? Designation { get; set; }
    public DateTime JoiningDate { get; set; }
    public DateTime ModifiedOn { get; set; }
    public Guid ModifiedBy { get; set; }
    public DateTime LeavingDate { get; set; }
    public bool AdminStatus { get; set; }
	public Guid CreatedBy { get; set; }
	public DateTime CreatedOn { get; set; }
}