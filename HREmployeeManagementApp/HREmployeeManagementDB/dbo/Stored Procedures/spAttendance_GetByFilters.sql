CREATE PROCEDURE [dbo].[spAttendance_GetByFilters]
	@EmployeeID int,
	@DateFrom date,
	@DateTo date,
	@Status nvarchar(50)
AS
Begin
	Select AttendanceID,EmployeeID,FirstName,LastName,Date,CheckIn,CheckOut,Status,ModifiedBy,ModifiedOn 
	from [dbo].[Attendance] where EmployeeID = @EmployeeID 
	and Date >= @DateFrom and Date <= @DateTo and Status = @Status 
	ORDER BY Date DESC
End