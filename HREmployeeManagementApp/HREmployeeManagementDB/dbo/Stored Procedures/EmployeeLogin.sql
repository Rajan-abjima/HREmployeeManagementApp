CREATE PROCEDURE [dbo].[EmployeeLogin]
    @username VARCHAR(20),
    @password VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT * FROM [dbo].[User] WHERE UserName = @username AND Password = @password and IsValid = 1)
        SELECT EmployeeID FROM [dbo].[User] WHERE UserName = @username AND Password = @password and IsValid = 1;
    ELSE
        SELECT 0;
END
