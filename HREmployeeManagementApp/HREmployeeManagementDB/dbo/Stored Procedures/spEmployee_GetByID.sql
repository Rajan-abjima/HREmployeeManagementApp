CREATE PROCEDURE [dbo].[spEmployee_GetByID]
@employeeID int
AS
BEGIN
	SELECT EmployeeID,FirstName,LastName,Gender,DateOfBirth,Address,Contact,Designation,SignInApprovedBy,JoiningDate,ModifiedDate,ModifiedBy,AdminStatus
	FROM [dbo].[Employee]
	WHERE EmployeeID = @employeeID;
END