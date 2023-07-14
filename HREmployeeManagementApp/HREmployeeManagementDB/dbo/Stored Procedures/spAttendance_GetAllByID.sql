CREATE Procedure [dbo].[spAttendance_GetAllByID]
	@EmployeeID int
AS
Begin
	Select AttendanceID,EmployeeID,FirstName,LastName,Date,CheckIn,CheckOut,Status,ModifiedBy,ModifiedOn from [dbo].[Attendance] where EmployeeID = @EmployeeID
End
