CREATE PROCEDURE [dbo].[spCredentials_Insert]
	@EmployeeID int,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@UserName nvarchar(50),
	@Password nvarchar(100),
	@IsValid bit
AS
BEGIN
	INSERT INTO [dbo].[Registration](EmployeeID, FirstName, LastName,UserName,Password,IsValid)
	VALUES (@EmployeeID, @FirstName,@LastName,@UserName,@Password,@IsValid)

	select 'true'
END
