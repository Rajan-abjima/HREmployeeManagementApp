CREATE TABLE [dbo].[RegularizationRecord] (
    [RegularizeID]    INT              IDENTITY (1, 1) NOT NULL,
    [AttendanceID]    INT              NOT NULL,
    [EmployeeID]      INT              NOT NULL,
    [RegularizeDate]  DATE             NOT NULL,
    [CheckedIn]       DATETIME         NULL,
    [CheckedOut]      DATETIME         NULL,
    [DateOfRequest]   DATE             CONSTRAINT [DF_RegularizationRecord_DateOfRequest] DEFAULT (getutcdate()) NOT NULL,
    [AppliedCheckIn]  DATETIME         NULL,
    [AppliedCheckOut] DATETIME         NULL,
    [Reason]          NVARCHAR (300)   NOT NULL,
    [RegularizedBy]   NVARCHAR (50)    NULL,
    [Decision]        INT              CONSTRAINT [DF_Decision] DEFAULT ((0)) NOT NULL,
    [Comment]         NVARCHAR (300)   NULL,
    [CreatedBy]       UNIQUEIDENTIFIER NOT NULL,
    [CreatedOn]       DATETIME         DEFAULT (getutcdate()) NOT NULL,
    [ModifiedOn]      DATETIME         DEFAULT (getutcdate()) NOT NULL,
    [ModifiedBy]      UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    CONSTRAINT [PK_RegularizationRecord] PRIMARY KEY CLUSTERED ([RegularizeID] ASC),
    CONSTRAINT [FK_RegularizationRecord_Attendance] FOREIGN KEY ([AttendanceID]) REFERENCES [dbo].[Attendance] ([AttendanceID]),
    CONSTRAINT [FK_RegularizationRecord_Employee] FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[Employee] ([EmployeeID])
);




GO

