CREATE TABLE [Resources] 
(
    [Id] [uniqueidentifier] NOT NULL,
    [FirstName] [nvarchar](100) NOT NULL,
    [LastName] [nvarchar](100) NOT NULL,
    [UserId] [uniqueidentifier] NOT NULL,
    [IsActive] [bit] NOT NULL,
    CONSTRAINT [PK_Resources] PRIMARY KEY CLUSTERED ([Id] ASC) ON [PRIMARY]
);
GO

ALTER TABLE [Resources] ADD CONSTRAINT [FK_Resources_Users_UserId] FOREIGN KEY([UserId]) REFERENCES [Users] ([Id])
GO

INSERT INTO [Resources] ([Id], [FirstName], [LastName], [UserId], [IsActive])
VALUES ('00000000-0000-0000-0001-000000000001', 'John', 'Doe', '00000000-0000-0000-0000-000000000001', 1);
INSERT INTO [Resources] ([Id], [FirstName], [LastName], [UserId], [IsActive])
VALUES ('00000000-0000-0000-0001-000000000002', 'Matt', 'Matthews', '00000000-0000-0000-0000-000000000002', 1);
INSERT INTO [Resources] ([Id], [FirstName], [LastName], [UserId], [IsActive])
VALUES ('00000000-0000-0000-0001-000000000003', 'Jane', 'Jonson', '00000000-0000-0000-0000-000000000003', 1);
GO