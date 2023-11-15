CREATE TABLE [dbo].[Interaccion]
(
	[IdInteraccion] INT NOT NULL PRIMARY KEY identity, 
    [idUsuario] INT NULL, 
    [idEvento] INT NULL, 
    [tipo] NCHAR(50) NULL, 
    [descripcion] NCHAR(50) NULL,
    FOREIGN KEY ([idUsuario]) REFERENCES [dbo].[Usuarios] ([idUsuario]),
    FOREIGN KEY ([idEvento]) REFERENCES [dbo].[Eventos] ([idEvento])
)
