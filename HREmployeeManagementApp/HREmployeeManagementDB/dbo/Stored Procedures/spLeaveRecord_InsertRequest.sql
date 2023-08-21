CREATE PROCEDURE [dbo].[spLeaveRecord_InsertRequest]
	@EmployeeID int,
	@FromDate date,
	@ToDate date,
	@DateOfRequest date,
	@Reason nvarchar(50),
	@LeaveRequestID int OUTPUT
AS
BEGIN
	INSERT INTO [dbo].[LeaveRecord] (EmployeeID,FromDate, ToDate, DateOfRequest, Reason, CreatedBy, ModifiedBy)
	VALUES (@EmployeeID, @FromDate, @ToDate, @DateOfRequest, @Reason, 
	(Select Identifier From [dbo].[User] where EmployeeID = @EmployeeID),
	(Select Identifier From [dbo].[User] where EmployeeID = @EmployeeID))

	SET @LeaveRequestID = SCOPE_IDENTITY();
END
