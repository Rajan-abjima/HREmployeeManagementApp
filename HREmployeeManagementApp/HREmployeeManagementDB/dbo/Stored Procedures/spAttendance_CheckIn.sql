
CREATE PROCEDURE [dbo].[spAttendance_CheckIn]
	@EmployeeID int,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Date date,
	@Status nvarchar(50) = 'Present',
	@CheckIn time(0),
	@AttendanceIdentity int OUTPUT

AS
BEGIN
	INSERT INTO [dbo].[Attendance](EmployeeID,FirstName,LastName,Date,Status,CheckIn)
	VALUES (@EmployeeID,@FirstName,@LastName,@Date,@Status,@CheckIn)

	SET @AttendanceIdentity = SCOPE_IDENTITY()
END
