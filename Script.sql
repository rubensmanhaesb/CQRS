IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [TAREFA] (
    [ID] uniqueidentifier NOT NULL,
    [NOME] nvarchar(100) NOT NULL,
    [DATAHORA] datetime2 NOT NULL,
    [DESCRICAO] nvarchar(250) NOT NULL,
    [PRIORIDADE] int NOT NULL,
    CONSTRAINT [PK_TAREFA] PRIMARY KEY ([ID])
);
GO

CREATE TABLE [Usuarios] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] nvarchar(150) NOT NULL,
    [Email] nvarchar(100) NOT NULL,
    [Senha] nvarchar(100) NOT NULL,
    [RefreshToken] nvarchar(100) NULL,
    [RefreshTokenExpiration] datetime2 NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY ([Id])
);
GO

CREATE UNIQUE INDEX [IX_Usuarios_Email] ON [Usuarios] ([Email]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241025221331_Initial', N'8.0.10');
GO

COMMIT;
GO

