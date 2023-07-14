CREATE PROCEDURE [dbo].[spLeaveRecord_GetByID]
	@leaveID int
AS
BEGIN
	SELECT * FROM [dbo].[LeaveRecord] WHERE LeaveID = @leaveID;
END