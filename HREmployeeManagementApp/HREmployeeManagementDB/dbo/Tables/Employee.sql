CREATE TABLE [dbo].[Employee] (
    [EmployeeID]                      INT              IDENTITY (10001, 1) NOT NULL,
    [FirstName]                       NVARCHAR (50)    NOT NULL,
    [LastName]                        NVARCHAR (50)    NOT NULL,
    [Gender]                          NVARCHAR (50)    NOT NULL,
    [DateOfBirth]                     DATETIME         NOT NULL,
    [PresentAddress]                  NVARCHAR (MAX)   NOT NULL,
    [MobileNumber]                    NVARCHAR (10)    NOT NULL,
    [Designation]                     NVARCHAR (20)    NOT NULL,
    [JoiningDate]                     DATETIME         CONSTRAINT [DF_Employee_Join] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedOn]                      DATETIME         CONSTRAINT [df_ModifiedOn] DEFAULT (getutcdate()) NULL,
    [ModifiedBy]                      UNIQUEIDENTIFIER NOT NULL,
    [LeavingDate]                     DATE             NULL,
    [AdminStatus]                     BIT              NOT NULL,
    [CreatedOn]                       DATETIME         DEFAULT (getutcdate()) NOT NULL,
    [CreatedBy]                       UNIQUEIDENTIFIER NOT NULL,
    [Identifier]                      UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Username]                        NVARCHAR (MAX)   NULL,
    [Password]                        NVARCHAR (MAX)   NULL,
    [MiddleName]                      NVARCHAR (MAX)   NULL,
    [Email]                           NVARCHAR (MAX)   NULL,
    [WorkMobileNumber]                NVARCHAR (MAX)   NULL,
    [MartialStatus]                   NVARCHAR (MAX)   NULL,
    [Hobbies]                         NVARCHAR (MAX)   NULL,
    [PermenantAddressAsPerAadharCard] NVARCHAR (MAX)   NULL,
    [City]                            NVARCHAR (MAX)   NULL,
    [ReportsTo]                       UNIQUEIDENTIFIER NULL,
    [IsValid]                         BIT              DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED ([EmployeeID] ASC),
    UNIQUE NONCLUSTERED ([Identifier] ASC)
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