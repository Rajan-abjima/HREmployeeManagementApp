CREATE PROCEDURE [dbo].[spAdminLogin]
	@adminID int,
	@adminpassword nvarchar(50)
AS
BEGIN
	IF EXISTS (SELECT * FROM [dbo].[AdminRegistration] WHERE AdminID = @adminID AND AdminPassword = @adminpassword)
        SELECT EmployeeID,AdminID FROM [dbo].[AdminRegistration] WHERE AdminID = @adminID AND AdminPassword = @adminpassword
    ELSE
        SELECT null;
END