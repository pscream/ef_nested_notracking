CREATE TABLE [TimesheetDetails] 
(
    [Id] [uniqueidentifier] NOT NULL,
    [TimesheetRowId] [uniqueidentifier] NOT NULL,
	[WorkDay] [date] NOT NULL,
	[Hours] [decimal] NOT NULL,
    [CreatedById] [uniqueidentifier] NOT NULL,
    [UpdatedById] [uniqueidentifier] NOT NULL,
    [IsActive] [bit] NOT NULL,
    CONSTRAINT [PK_TimesheetDetails] PRIMARY KEY ([Id] ASC) ON [PRIMARY]
);
GO

ALTER TABLE [TimesheetDetails] ADD CONSTRAINT [FK_TimesheetDetails_TimesheetRows_TimesheetRowId] FOREIGN KEY([TimesheetRowId]) REFERENCES [TimesheetRows] ([Id])
GO

ALTER TABLE [TimesheetDetails] ADD CONSTRAINT [FK_TimesheetDetails_Users_CreatedById] FOREIGN KEY([CreatedById]) REFERENCES [Users] ([Id])
GO

ALTER TABLE [TimesheetDetails] ADD CONSTRAINT [FK_TimesheetDetails_Users_UpdatedById] FOREIGN KEY([UpdatedById]) REFERENCES [Users] ([Id])
GO

INSERT INTO [TimesheetDetails] ([Id], [TimesheetRowId], [WorkDay], [Hours], [CreatedById], [UpdatedById], [IsActive])
VALUES ('00000000-0000-0000-0001-000000000001', '00000000-0000-0000-0000-000000000001', '2022-08-01', 8, '00000000-0000-0000-0000-000000000001', '00000000-0000-0000-0000-000000000001', 1);

INSERT INTO [TimesheetDetails] ([Id], [TimesheetRowId], [WorkDay], [Hours], [CreatedById], [UpdatedById], [IsActive])
VALUES ('00000000-0000-0000-0001-000000000002', '00000000-0000-0000-0000-000000000001', '2022-08-02', 8, '00000000-0000-0000-0000-000000000001', '00000000-0000-0000-0000-000000000001', 1);

INSERT INTO [TimesheetDetails] ([Id], [TimesheetRowId], [WorkDay], [Hours], [CreatedById], [UpdatedById], [IsActive])
VALUES ('00000000-0000-0000-0001-000000000003', '00000000-0000-0000-0000-000000000001', '2022-08-03', 8, '00000000-0000-0000-0000-000000000001', '00000000-0000-0000-0000-000000000001', 1);

INSERT INTO [TimesheetDetails] ([Id], [TimesheetRowId], [WorkDay], [Hours], [CreatedById], [UpdatedById], [IsActive])
VALUES ('00000000-0000-0000-0001-000000000004', '00000000-0000-0000-0000-000000000001', '2022-08-04', 8, '00000000-0000-0000-0000-000000000001', '00000000-0000-0000-0000-000000000001', 1);

INSERT INTO [TimesheetDetails] ([Id], [TimesheetRowId], [WorkDay], [Hours], [CreatedById], [UpdatedById], [IsActive])
VALUES ('00000000-0000-0000-0001-000000000005', '00000000-0000-0000-0000-000000000001', '2022-08-05', 8, '00000000-0000-0000-0000-000000000001', '00000000-0000-0000-0000-000000000001', 1);

INSERT INTO [TimesheetDetails] ([Id], [TimesheetRowId], [WorkDay], [Hours], [CreatedById], [UpdatedById], [IsActive])
VALUES ('00000000-0000-0000-0001-000000000006', '00000000-0000-0000-0000-000000000001', '2022-08-06', 8, '00000000-0000-0000-0000-000000000001', '00000000-0000-0000-0000-000000000001', 1);

INSERT INTO [TimesheetDetails] ([Id], [TimesheetRowId], [WorkDay], [Hours], [CreatedById], [UpdatedById], [IsActive])
VALUES ('00000000-0000-0000-0001-000000000007', '00000000-0000-0000-0000-000000000001', '2022-08-07', 8, '00000000-0000-0000-0000-000000000001', '00000000-0000-0000-0000-000000000001', 1);

