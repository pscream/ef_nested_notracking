CREATE TABLE [TimesheetRows] 
(
    [Id] [uniqueidentifier] NOT NULL,
    [IsBillable] [bit] NOT NULL,
    [CreatedById] [uniqueidentifier] NOT NULL,
    [UpdatedById] [uniqueidentifier] NOT NULL,
    [IsActive] [bit] NOT NULL,
    CONSTRAINT [PK_TimesheetRows] PRIMARY KEY ([Id] ASC) ON [PRIMARY]
);
GO

ALTER TABLE [TimesheetRows] ADD CONSTRAINT [FK_TimesheetRows_Users_CreatedById] FOREIGN KEY([CreatedById]) REFERENCES [Users] ([Id])
GO

ALTER TABLE [TimesheetRows] ADD CONSTRAINT [FK_TimesheetRows_Users_UpdatedById] FOREIGN KEY([UpdatedById]) REFERENCES [Users] ([Id])
GO

INSERT INTO [TimesheetRows] ([Id], [IsBillable], [CreatedById], [UpdatedById], [IsActive])
VALUES ('00000000-0000-0000-0000-000000000001', 1, '00000000-0000-0000-0000-000000000001', '00000000-0000-0000-0000-000000000001', 1);