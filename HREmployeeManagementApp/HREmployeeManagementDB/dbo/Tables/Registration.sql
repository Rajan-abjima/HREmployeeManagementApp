CREATE TABLE [dbo].[Registration] (
    [ID]         INT            IDENTITY (1, 1) NOT NULL,
    [EmployeeID] INT            NOT NULL,
    [FirstName]  NVARCHAR (50)  NOT NULL,
    [LastName]   NVARCHAR (50)  NOT NULL,
    [UserName]   NVARCHAR (50)  NOT NULL,
    [Password]   NVARCHAR (100) NOT NULL,
    [IsValid]    BIT            NOT NULL,
    CONSTRAINT [PK_Registration] PRIMARY KEY CLUSTERED ([ID] ASC)
);

