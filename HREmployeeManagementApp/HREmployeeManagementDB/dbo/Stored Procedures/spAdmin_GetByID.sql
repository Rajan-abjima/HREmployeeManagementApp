CREATE PROCEDURE [dbo].[spAdmin_GetByID]
	@adminID int
AS
BEGIN
	SELECT * FROM [dbo].[Admin] where AdminID = @adminID
END