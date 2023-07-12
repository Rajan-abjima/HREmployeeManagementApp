CREATE PROCEDURE [dbo].[spLeaveRecord_InsertRequest]
	@EmployeeID int,
	@FromDate date,
	@ToDate date,
	@DateOfRequest date,
	@Reason nvarchar(50),
	@LeaveRequestID int OUTPUT
AS
BEGIN
	INSERT INTO [dbo].[LeaveRecord] (EmployeeID,FromDate, ToDate, DateOfRequest, Reason)
	VALUES (@EmployeeID, @FromDate, @ToDate, @DateOfRequest, @Reason)

	SET @LeaveRequestID = SCOPE_IDENTITY();
END
