CREATE PROCEDURE [dbo].[spRegularization_InsertRequest]
	@AttendanceID int,
	@EmployeeID int OUTPUT,
	@RegularizeDate date,
	@CheckedIn time(0),
	@CheckedOut time(0),
	@DateOfRequest date,
	@AppliedCheckIn time(0),
	@AppliedCheckOut time(0),
	@Reason nvarchar(300),
	@RegularizeIdentity int OUTPUT
AS
BEGIN
	INSERT INTO [dbo].[RegularizationRecord] 
	(AttendanceID,EmployeeID,RegularizeDate,CheckedIn, CheckedOut, DateOfRequest,AppliedCheckIn,AppliedCheckOut,Reason)
	VALUES
	(@AttendanceID,@EmployeeID,@RegularizeDate,@CheckedIn,@CheckedOut,@DateOfRequest,@AppliedCheckIn,@AppliedCheckOut,@Reason)

	Set @RegularizeIdentity = SCOPE_IDENTITY();
END