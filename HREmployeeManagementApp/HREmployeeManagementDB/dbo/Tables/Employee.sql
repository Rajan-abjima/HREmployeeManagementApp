CREATE TABLE [dbo].[Employee] (
    [EmployeeID]       INT            IDENTITY (10001, 1) NOT NULL,
    [FirstName]        NVARCHAR (50)  NOT NULL,
    [LastName]         NVARCHAR (50)  NOT NULL,
    [Gender]           NVARCHAR (50)  NOT NULL,
    [DateOfBirth]      DATETIME       NOT NULL,
    [Address]          NVARCHAR (MAX) NOT NULL,
    [Contact]          NVARCHAR (10)  NOT NULL,
    [Designation]      NVARCHAR (20)  NOT NULL,
    [SignInApprovedBy] NVARCHAR (50)  NULL,
    [JoiningDate]      DATETIME       CONSTRAINT [DF_Employee_Join] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedDate]     DATE           CONSTRAINT [DF_Employee_Modify] DEFAULT (getutcdate()) NULL,
    [ModifiedBy]       NVARCHAR (50)  NULL,
    [LeavingDate]      DATE           CONSTRAINT [DF_Employee_Leave] DEFAULT (getutcdate()) NULL,
    [AdminStatus]      BIT            NOT NULL,
    CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED ([EmployeeID] ASC)
);


GO
CREATE TRIGGER PopulateAdminOnInsert
on [dbo].[Employee]
AFTER INSERT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM inserted WHERE AdminStatus = 1)
    BEGIN
        INSERT INTO [dbo].[Admin] (AdminStatus, EmployeeID, FirstName, LastName, Designation)
        SELECT AdminStatus, EmployeeID, FirstName, LastName, Designation
        FROM inserted
        WHERE AdminStatus = 1
    END
END
GO
CREATE TRIGGER PopulateAdminOnUpdate
on [dbo].[Employee]
AFTER Update 
AS
BEGIN
	IF UPDATE (AdminStatus)
	BEGIN
	  INSERT INTO [dbo].[Admin](AdminStatus,EmployeeID,FirstName,LastName,Designation)
	  SELECT AdminStatus, EmployeeID, FirstName, LastName, Designation
	  FROM inserted
	  WHERE AdminStatus = 1
	END
END