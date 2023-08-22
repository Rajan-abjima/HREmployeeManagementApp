CREATE TABLE [dbo].[User] (
    [ID]         INT              IDENTITY (1, 1) NOT NULL,
    [EmployeeID] INT              NOT NULL,
    [FirstName]  NVARCHAR (50)    NOT NULL,
    [LastName]   NVARCHAR (50)    NOT NULL,
    [UserName]   NVARCHAR (50)    NOT NULL,
    [Password]   NVARCHAR (100)   NOT NULL,
    [IsValid]    BIT              NOT NULL,
    [Identifier] UNIQUEIDENTIFIER CONSTRAINT [df_IdentifierGenerate] DEFAULT (newid()) NOT NULL,
    [CreatedOn]  DATETIME         DEFAULT (getutcdate()) NOT NULL,
    [ModifiedOn] DATETIME         DEFAULT (getutcdate()) NOT NULL,
    [CreatedBy]  UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [ModifiedBy] UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    CONSTRAINT [PK_Registration] PRIMARY KEY CLUSTERED ([ID] ASC)
);

