CREATE PROCEDURE [dbo].[spLeaveRecord_ListOfPendings]
AS
BEGIN
	Select * From [dbo].[LeaveRecord] Where ApprovalStatus is null ORDER BY EmployeeID;
END
