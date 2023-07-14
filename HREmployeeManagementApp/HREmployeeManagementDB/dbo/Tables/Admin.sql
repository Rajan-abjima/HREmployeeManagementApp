CREATE TABLE [dbo].[Admin] (
    [AdminStatus]          BIT           NOT NULL,
    [AdminID]              INT           IDENTITY (101, 1) NOT NULL,
    [EmployeeID]           INT           NOT NULL,
    [FirstName]            NVARCHAR (50) NOT NULL,
    [LastName]             NVARCHAR (50) NOT NULL,
    [Designation]          NVARCHAR (50) NOT NULL,
    [AdminCreationDate]    DATE          CONSTRAINT [DF_Admin] DEFAULT (getutcdate()) NOT NULL,
    [AdminTerminationDate] DATE          CONSTRAINT [DF_AdminT] DEFAULT (getutcdate()) NULL,
    CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED ([AdminID] ASC),
    CONSTRAINT [FK_Admin_Employee] FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[Employee] ([EmployeeID])
);

