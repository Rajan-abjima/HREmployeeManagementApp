CREATE TABLE [dbo].[LeaveRecord] (
    [LeaveID]        INT            IDENTITY (1, 1) NOT NULL,
    [EmployeeID]     INT            NOT NULL,
    [FromDate]       DATE           NOT NULL,
    [ToDate]         DATE           NOT NULL,
    [DateOfRequest]  DATE           CONSTRAINT [DF_LeaveRecord_DateOfRequest] DEFAULT (getutcdate()) NOT NULL,
    [Reason]         NVARCHAR (300) NOT NULL,
    [AdministeredBy] NVARCHAR (50)  NULL,
    [ApprovalStatus] BIT            NULL,
    [Comment]        NVARCHAR (300) NULL,
    CONSTRAINT [PK_LeaveRecord] PRIMARY KEY CLUSTERED ([LeaveID] ASC),
    CONSTRAINT [FK_LeaveRecord_Employee] FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[Employee] ([EmployeeID])
);


GO
CREATE TRIGGER [dbo].[ChangeAttendanceOnUpdate]
   ON [dbo].[LeaveRecord]
   AFTER UPDATE
AS 
BEGIN
	IF UPDATE (ApprovalStatus)
	BEGIN
		Declare @CurrentEmployeeID int;
		Set @CurrentEmployeeID = (Select EmployeeID from inserted);
		INSERT INTO [dbo].[Attendance] (EmployeeID, FirstName, LastName, Date, Status,CheckIn,CheckOut, ModifiedBy, ModifiedOn)
		VALUES((@CurrentEmployeeID),(Select FirstName from [dbo].[Employee] where EmployeeID = @CurrentEmployeeID),
			(Select LastName from [dbo].[Employee] where EmployeeID = @CurrentEmployeeID),
			 (Select ToDate from inserted),'leave',null, null, (Select AdministeredBy from inserted), GETDATE());
	END
END
