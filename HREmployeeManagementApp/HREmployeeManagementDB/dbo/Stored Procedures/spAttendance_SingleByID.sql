Create Procedure [dbo].[spAttendance_SingleByID]
	@AttendanceID int
AS
BEGIN
	Select * from [dbo].[Attendance] where AttendanceID = @AttendanceID
END