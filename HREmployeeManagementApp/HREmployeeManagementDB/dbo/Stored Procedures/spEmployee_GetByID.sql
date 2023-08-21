CREATE PROCEDURE [dbo].[spEmployee_GetByID]
@employeeID int
AS
BEGIN
	SELECT EmployeeID,FirstName,LastName,Gender,DateOfBirth,PresentAddress,MobileNumber,Designation,JoiningDate,ModifiedOn,ModifiedBy,AdminStatus
	FROM [dbo].[Employee]
	WHERE EmployeeID = @employeeID;
END