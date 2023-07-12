CREATE TABLE [dbo].[AdminRegistration] (
    [ID]            INT           IDENTITY (1, 1) NOT NULL,
    [EmployeeID]    INT           NOT NULL,
    [AdminID]       INT           NOT NULL,
    [AdminPassword] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_AdminRegistration] PRIMARY KEY CLUSTERED ([ID] ASC)
);

