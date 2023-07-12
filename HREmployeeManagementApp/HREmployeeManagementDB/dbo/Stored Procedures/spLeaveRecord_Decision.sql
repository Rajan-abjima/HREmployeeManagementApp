CREATE PROCEDURE [dbo].[spLeaveRecord_Decision]
	@leaveID int,
	@AdministeredBy nvarchar(50),
	@ApprovalStatus bit,
	@Comment nvarchar(300)
AS
BEGIN
	UPDATE [dbo].[LeaveRecord]
	SET AdministeredBy = @AdministeredBy, ApprovalStatus = @ApprovalStatus, Comment = @Comment
	WHERE LeaveID = @leaveID;
END