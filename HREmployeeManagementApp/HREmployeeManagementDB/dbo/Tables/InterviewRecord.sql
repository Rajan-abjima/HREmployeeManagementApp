CREATE TABLE [dbo].[InterviewRecord] (
    [CandidateName]   NVARCHAR (50)   NOT NULL,
    [PositionApplied] NVARCHAR (50)   NOT NULL,
    [InterviewDate]   DATE            CONSTRAINT [DF_InterviewRecord_InterviewDate] DEFAULT (getdate()) NOT NULL,
    [InterviewTime]   DATETIME        CONSTRAINT [DF_InterviewRecord_InterviewTime] DEFAULT (getdate()) NOT NULL,
    [RowData]         VARBINARY (MAX) NOT NULL,
    [ColumnData]      VARBINARY (MAX) NOT NULL
);

