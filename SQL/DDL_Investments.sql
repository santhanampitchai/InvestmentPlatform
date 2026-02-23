CREATE TABLE [dbo].[Investments]
(
    [Id] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    [UserId] UNIQUEIDENTIFIER NOT NULL,
    [Name] NVARCHAR(100) NOT NULL,
    [Type] INT NOT NULL,
    [Amount] DECIMAL(18,2) NOT NULL,
    [Quantity] INT NOT NULL,
    [PurchaseDate] DATETIME2 NOT NULL,

    [CreatedAt] DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
    [ModifiedAt] DATETIME2 NULL,
    [IsDeleted] BIT NOT NULL DEFAULT 0,

    CONSTRAINT [PK_Investments] PRIMARY KEY CLUSTERED ([Id])
);

CREATE NONCLUSTERED INDEX [IX_Investments_UserId]
ON [dbo].[Investments] ([UserId]);

CREATE NONCLUSTERED INDEX [IX_Investments_UserId_PurchaseDate]
ON [dbo].[Investments] ([UserId], [PurchaseDate] DESC);