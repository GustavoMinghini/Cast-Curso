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

CREATE TABLE [Categorias] (
    [CategoriasId] int NOT NULL IDENTITY,
    [CategoriasNome] varchar(100) NOT NULL,
    CONSTRAINT [PK_Categorias] PRIMARY KEY ([CategoriasId])
);
GO

CREATE TABLE [Curso] (
    [CursoId] int NOT NULL IDENTITY,
    [DescricaoCurso] varchar(100) NOT NULL,
    [DtInicio] DateTime NOT NULL,
    [DtTermino] DateTime NOT NULL,
    [QtdAlunos] int NOT NULL,
    [CategoriasId] int NOT NULL,
    CONSTRAINT [PK_Curso] PRIMARY KEY ([CursoId])
);
GO

CREATE TABLE [TabelaLog] (
    [TabelaLogId] int NOT NULL IDENTITY,
    [DtInclusao] DateTime NULL,
    [dtUltimaAtt] DateTime NULL,
    [UsuarioResponsavel] varchar(100) NOT NULL,
    [CursoId] int NOT NULL,
    CONSTRAINT [PK_TabelaLog] PRIMARY KEY ([TabelaLogId])
);
GO

CREATE TABLE [Usuarios] (
    [UsuarioId] int NOT NULL IDENTITY,
    [NomeUsuario] varchar(100) NOT NULL,
    [Login] varchar(100) NOT NULL,
    [Senha] varchar(100) NOT NULL,
    [Cargo] varchar(100) NOT NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY ([UsuarioId])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211117223928_Initial', N'5.0.12');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Curso] ADD [CursoNome] varchar(100) NOT NULL DEFAULT '';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211118120549_Finalx', N'5.0.12');
GO

COMMIT;
GO

