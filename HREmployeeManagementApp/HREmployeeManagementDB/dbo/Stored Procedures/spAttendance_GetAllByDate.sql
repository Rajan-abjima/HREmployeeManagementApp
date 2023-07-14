CREATE PROCEDURE [dbo].[spAttendance_GetAllByDate]
	@EmployeeID int,
	@Date date
AS
BEGIN
	Select EmployeeID,FirstName,LastName,Date,Status,CheckIn,CheckOut,ModifiedBy,ModifiedOn FROM [dbo].[Attendance] where Date = @Date
END