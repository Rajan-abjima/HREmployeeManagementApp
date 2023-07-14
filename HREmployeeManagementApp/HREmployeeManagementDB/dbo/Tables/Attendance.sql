CREATE TABLE [dbo].[Attendance] (
    [AttendanceID] INT           IDENTITY (1, 1) NOT NULL,
    [EmployeeID]   INT           NOT NULL,
    [FirstName]    NVARCHAR (50) NOT NULL,
    [LastName]     NVARCHAR (50) NOT NULL,
    [Date]         DATE          CONSTRAINT [DF_Attendance_Date] DEFAULT (CONVERT([date],getutcdate())) NOT NULL,
    [Status]       NVARCHAR (50) NOT NULL,
    [CheckIn]      TIME (0)      NULL,
    [CheckOut]     TIME (0)      CONSTRAINT [DEFAULT_Attendance_CheckOut] DEFAULT ('23:59:59') NULL,
    [ModifiedBy]   NVARCHAR (50) NULL,
    [ModifiedOn]   DATETIME      NULL,
    CONSTRAINT [PK_Attendance] PRIMARY KEY CLUSTERED ([AttendanceID] ASC),
    CONSTRAINT [FK_Attendance_Employee] FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[Employee] ([EmployeeID])
);

