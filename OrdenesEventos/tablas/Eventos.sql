CREATE TABLE [dbo].[Eventos]
(
	[idEvento] INT NOT NULL PRIMARY KEY identity, 
    [nombre] NCHAR(50) NULL, 
    [descripcion] NCHAR(50) NULL, 
    [fechaEvento] DATE NULL, 
    [horaInicio] NCHAR(50) NULL, 
    [horaFin] NCHAR(50) NULL, 
    [lugar] NCHAR(50) NULL, 
    [estado] NCHAR(20) NULL, 
    [fechaCreacion] DATETIME NULL, 
    [MomentosImportantes] NCHAR(300) NULL, 
    [CantidadInvitados] INT NULL, 
    [idUsuario] INT NULL,
    FOREIGN KEY ([idUsuario]) REFERENCES [dbo].[Usuarios] ([idUsuario])
)
