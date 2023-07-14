CREATE PROCEDURE [dbo].[spRegularization_GetByID]
	@regularizeID int
AS
BEGIN
	SELECT * FROM [dbo].[RegularizationRecord] WHERE RegularizeID = @regularizeID;
END