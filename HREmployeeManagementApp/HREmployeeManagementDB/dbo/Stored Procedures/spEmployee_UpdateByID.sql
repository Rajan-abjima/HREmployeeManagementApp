CREATE PROCEDURE [dbo].[spEmployee_UpdateByID]
	@employeeID int,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Gender nvarchar(50),
	@DateOfBirth datetime,
	@Address nvarchar(100),
	@Contact nvarchar(10),
	@Designation nvarchar(50),
	@SignInApprovedBy nvarchar(50),
	@JoiningDate datetime,
	@ModifiedDate date,
	@ModifiedBy nvarchar(50),
	@AdminStatus bit
AS
BEGIN
	Update [dbo].[Employee]
	Set FirstName = @FirstName, LastName =@LastName, Gender=@Gender, DateOfBirth=@DateOfBirth,
		Address=@Address, Contact=@Contact, Designation=@Designation, SignInApprovedBy=@SignInApprovedBy, JoiningDate=@JoiningDate,
		ModifiedDate=GETDATE(), ModifiedBy=@ModifiedBy,LeavingDate = null, AdminStatus=@AdminStatus
	Where EmployeeID = @employeeID;
END