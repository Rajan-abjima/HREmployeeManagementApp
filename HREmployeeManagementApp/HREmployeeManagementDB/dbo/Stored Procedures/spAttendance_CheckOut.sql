CREATE PROCEDURE [dbo].[spAttendance_CheckOut]
	@AttendanceID int,
	@CheckOut time
AS
BEGIN
	update [dbo].[Attendance] set CheckOut = @CheckOut where AttendanceID = @AttendanceID
END
