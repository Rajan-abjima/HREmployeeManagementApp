CREATE PROCEDURE [dbo].[spRegularization_Decision]
	@regularizeID int,
	@regularizedBy nvarchar(50),
	@approved bit,
	@comment nvarchar(300)
AS
BEGIN
	Update [dbo].[RegularizationRecord]
	SET RegularizedBy = @regularizedBy, Approved = @approved, Comment = @comment
	Where RegularizeID = @regularizeID;
END