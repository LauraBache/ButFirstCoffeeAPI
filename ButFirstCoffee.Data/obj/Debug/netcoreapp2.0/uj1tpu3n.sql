IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [BeverageCategories] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_BeverageCategories] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Condiments] (
    [Id] int NOT NULL IDENTITY,
    [Description] nvarchar(max) NULL,
    [DetailedDescription] nvarchar(max) NULL,
    [Price] decimal(18, 2) NOT NULL,
    CONSTRAINT [PK_Condiments] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Orders] (
    [Id] int NOT NULL IDENTITY,
    [Completed] bit NOT NULL,
    [OrderDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Sales] (
    [Id] int NOT NULL IDENTITY,
    [Description] nvarchar(max) NULL,
    [Name] nvarchar(max) NULL,
    [Percent] decimal(18, 2) NOT NULL,
    [Type] int NOT NULL,
    CONSTRAINT [PK_Sales] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Beverages] (
    [Id] int NOT NULL IDENTITY,
    [CategoryId] int NOT NULL,
    [Description] nvarchar(max) NULL,
    [DetailedDescription] nvarchar(max) NULL,
    [Price] decimal(18, 2) NOT NULL,
    CONSTRAINT [PK_Beverages] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Beverages_BeverageCategories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [BeverageCategories] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [BeverageSales] (
    [BeverageId] int NOT NULL,
    [SaleId] int NOT NULL,
    [DateFrom] datetime2 NOT NULL,
    [DateTo] datetime2 NOT NULL,
    CONSTRAINT [PK_BeverageSales] PRIMARY KEY ([BeverageId], [SaleId]),
    CONSTRAINT [FK_BeverageSales_Beverages_BeverageId] FOREIGN KEY ([BeverageId]) REFERENCES [Beverages] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_BeverageSales_Sales_SaleId] FOREIGN KEY ([SaleId]) REFERENCES [Sales] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [OrderItems] (
    [Id] int NOT NULL IDENTITY,
    [BeverageId] int NOT NULL,
    [Description] nvarchar(max) NULL,
    [OrderId] int NOT NULL,
    [Quantity] int NOT NULL,
    [UnitPrice] decimal(18, 2) NOT NULL,
    CONSTRAINT [PK_OrderItems] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_OrderItems_Beverages_BeverageId] FOREIGN KEY ([BeverageId]) REFERENCES [Beverages] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_OrderItems_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Beverages_CategoryId] ON [Beverages] ([CategoryId]);

GO

CREATE INDEX [IX_BeverageSales_SaleId] ON [BeverageSales] ([SaleId]);

GO

CREATE INDEX [IX_OrderItems_BeverageId] ON [OrderItems] ([BeverageId]);

GO

CREATE INDEX [IX_OrderItems_OrderId] ON [OrderItems] ([OrderId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180317183101_init', N'2.0.1-rtm-125');

GO

