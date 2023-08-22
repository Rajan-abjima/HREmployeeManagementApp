CREATE PROCEDURE [dbo].[spLeaveRecord_GetAll]
AS
BEGIN
	Select * from [dbo].[LeaveRecord] ORDER BY DateOfRequest DESC;
END