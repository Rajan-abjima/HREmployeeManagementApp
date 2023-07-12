CREATE PROCEDURE [dbo].[spEmployee_InsertByEmployee]
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Gender nvarchar(50),
	@DateOfBirth datetime,
	@Address nvarchar(100),
	@Contact nvarchar(10),
	@Designation nvarchar(50),
	@SignInApprovedBy nvarchar(50),
	@JoiningDate datetime,
	@AdminStatus bit = 0,
	@FirstNameOutput nvarchar(50) OUTPUT,
	@LastNameOutput nvarchar(50) OUTPUT,
	@EmployeeIdentity int OUTPUT
AS
begin
	INSERT INTO dbo.[Employee](FirstName,LastName,Gender,DateOfBirth,
						Address,Contact,Designation,SignInApprovedBy,JoiningDate,AdminStatus)
	VALUES (@FirstName,@LastName,@Gender,@DateOfBirth,
						@Address,@Contact,@Designation,@SignInApprovedBy,@JoiningDate,@AdminStatus)
	SET @EmployeeIdentity = SCOPE_IDENTITY() 
	SET @FirstNameOutput= @FirstName
	SET @LastNameOutput = @LastName
end