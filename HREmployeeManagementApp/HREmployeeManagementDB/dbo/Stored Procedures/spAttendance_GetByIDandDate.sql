
CREATE PROCEDURE [dbo].[spAttendance_GetByIDandDate]
	@EmployeeID int,
	@Date date

AS
BEGIN
	SELECT Top 1 EmployeeID, Date,Status, 
		(Select MIN(CheckIn) from Attendance where EmployeeID = @EmployeeID and Date = @Date) as CheckIn,
		(Select MAX(CheckOut) from Attendance where EmployeeID = @EmployeeID and Date = @Date) as CheckOut,
		ModifiedBy, ModifiedOn
		FROM [dbo].[Attendance]
		WHERE EmployeeID = @EmployeeID AND Date = @Date
END
