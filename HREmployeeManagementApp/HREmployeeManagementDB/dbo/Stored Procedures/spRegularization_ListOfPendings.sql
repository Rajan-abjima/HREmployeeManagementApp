CREATE PROCEDURE [dbo].[spRegularization_ListOfPendings]
AS
BEGIN
	SELECT * FROM [dbo].[RegularizationRecord] where Decision = 0 Order by DateOfRequest ASC;
END