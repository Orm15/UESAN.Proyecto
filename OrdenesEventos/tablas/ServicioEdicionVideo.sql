CREATE TABLE [dbo].[ServicioEdicionVideo]
(
	[idServicioEdicionVideo] INT NOT NULL PRIMARY KEY identity, 
    [idEvento] INT NULL, 
    [idUsuario] INT NULL, 
    [NombreProyecto] NCHAR(50) NULL, 
    [Objetivo] NCHAR(80) NULL, 
    [Musica] NCHAR(100) NULL, 
    [Logos] NCHAR(100) NULL,
    [FormatoVideo] Nchar(20) null,
    [Destino] Nchar(20) null,
    [DuracionVideo] nchar(15) null,
    [NombreEntrevistado] nchar(100) null,
    [CarreraCargoEmpresa] Nchar(100) null,
    [Estado] Nchar(15) null,
    FOREIGN KEY ([idEvento]) REFERENCES [dbo].[Eventos] ([idEvento]),
    FOREIGN KEY ([idUsuario]) REFERENCES [dbo].[Usuarios] ([idUsuario]),

)
