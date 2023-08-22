CREATE PROCEDURE [dbo].[spRegularization_GetAll]
AS
BEGIN
	Select * from [dbo].[RegularizationRecord] ORDER BY DateOfRequest DESC;
END