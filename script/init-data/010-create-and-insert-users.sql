CREATE TABLE [Users] 
(
    [Id] [uniqueidentifier] NOT NULL,
    [UserName] [nvarchar](256) NOT NULL,
    [IsActive] [bit] NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC) ON [PRIMARY]
);
GO

INSERT INTO [Users] ([Id], [UserName], [IsActive])
VALUES ('00000000-0000-0000-0000-000000000001', 'john.doe@abc.com', 1);

INSERT INTO [Users] ([Id], [UserName], [IsActive])
VALUES ('00000000-0000-0000-0000-000000000002', 'matt.matthews@abc.com', 1);

INSERT INTO [Users] ([Id], [UserName], [IsActive])
VALUES ('00000000-0000-0000-0000-000000000003', 'jane.jonson@abc.com', 1);
GO