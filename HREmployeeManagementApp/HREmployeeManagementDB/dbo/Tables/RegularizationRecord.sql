CREATE TABLE [dbo].[RegularizationRecord] (
    [RegularizeID]    INT            IDENTITY (1, 1) NOT NULL,
    [AttendanceID]    INT            NOT NULL,
    [EmployeeID]      INT            NOT NULL,
    [RegularizeDate]  DATE           NOT NULL,
    [CheckedIn]       TIME (0)       NOT NULL,
    [CheckedOut]      TIME (0)       NOT NULL,
    [DateOfRequest]   DATE           CONSTRAINT [DF_RegularizationRecord_DateOfRequest] DEFAULT (getutcdate()) NOT NULL,
    [AppliedCheckIn]  TIME (0)       NULL,
    [AppliedCheckOut] TIME (0)       NULL,
    [Reason]          NVARCHAR (300) NOT NULL,
    [RegularizedBy]   NVARCHAR (50)  NULL,
    [Approved]        BIT            NULL,
    [Comment]         NVARCHAR (300) NULL,
    CONSTRAINT [PK_RegularizationRecord] PRIMARY KEY CLUSTERED ([RegularizeID] ASC),
    CONSTRAINT [FK_RegularizationRecord_Attendance] FOREIGN KEY ([AttendanceID]) REFERENCES [dbo].[Attendance] ([AttendanceID]),
    CONSTRAINT [FK_RegularizationRecord_Employee] FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[Employee] ([EmployeeID])
);


GO
CREATE TRIGGER [dbo].[RegularizeAttendanceOnUpdate]
   ON [dbo].[RegularizationRecord]
   AFTER UPDATE
AS 
BEGIN
	IF UPDATE (Approved)
	BEGIN
	  UPDATE [dbo].[Attendance] SET CheckIn = AppliedCheckIn, CheckOut = AppliedCheckOut, ModifiedBy = RegularizedBy, ModifiedOn = GETUTCDATE()
	  FROM inserted 
	  Where inserted.Approved = 1 AND Attendance.AttendanceID = inserted.AttendanceID
	END
END
