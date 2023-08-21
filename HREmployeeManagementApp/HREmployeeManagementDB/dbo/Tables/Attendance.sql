CREATE TABLE [dbo].[Attendance] (
    [AttendanceID]  INT              IDENTITY (1, 1) NOT NULL,
    [EmployeeID]    INT              NOT NULL,
    [FirstName]     NVARCHAR (50)    NOT NULL,
    [LastName]      NVARCHAR (50)    NOT NULL,
    [Date]          DATE             CONSTRAINT [DF_Attendance_Date] DEFAULT (CONVERT([date],getutcdate())) NOT NULL,
    [Status]        NVARCHAR (50)    NOT NULL,
    [CheckIn]       DATETIME         NULL,
    [CheckOut]      DATETIME         NULL,
    [ModifiedBy]    UNIQUEIDENTIFIER NOT NULL,
    [CreatedOn]     DATE             CONSTRAINT [DF_Attendance_CreatedOn] DEFAULT (getutcdate()) NOT NULL,
    [CreatedBy]     UNIQUEIDENTIFIER NOT NULL,
    [ModifiedOn]    DATETIME         NOT NULL,
    [IsRegularized] BIT              DEFAULT ('false') NOT NULL,
    CONSTRAINT [PK_Attendance] PRIMARY KEY CLUSTERED ([AttendanceID] ASC),
    CONSTRAINT [FK_Attendance_Employee] FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[Employee] ([EmployeeID])
);



