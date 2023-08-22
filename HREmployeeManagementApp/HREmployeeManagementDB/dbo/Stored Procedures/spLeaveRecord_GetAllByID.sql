CREATE PROCEDURE [dbo].[spLeaveRecord_GetAllByID]
	@employeeID int
AS
BEGIN
	Select * from [dbo].[LeaveRecord] where EmployeeID = @employeeID ORDER BY DateOfRequest DESC; 
END