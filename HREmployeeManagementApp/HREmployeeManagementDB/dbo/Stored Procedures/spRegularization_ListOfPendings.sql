CREATE PROCEDURE [dbo].[spRegularization_ListOfPendings]
AS
BEGIN
	SELECT * FROM [dbo].[RegularizationRecord] where Approved is null Order by DateOfRequest ASC;
END