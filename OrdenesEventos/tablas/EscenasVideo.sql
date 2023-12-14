CREATE TABLE [dbo].[EscenasVideo]
(
	[idEscena] INT NOT NULL PRIMARY KEY identity, 
    [idServicioEdicionVideo] INT NULL, 
    [idVideo] INT NULL, 
    [nombreVideo] NCHAR(50) NULL, 
    [linkVideo] NCHAR(100) NULL, 
    [nombreEscena] NCHAR(50) NULL, 
    [DescripcionEscena] NCHAR(100) NULL, 
    [tiempo] NCHAR(20) NULL, 
    [Cambios] NCHAR(50) NULL, 
    [estado] NCHAR(15) NULL,
    FOREIGN KEY ([idServicioEdicionVideo]) REFERENCES [dbo].[ServicioEdicionVideo] ([idServicioEdicionVideo]),
    FOREIGN KEY ([idVideo]) REFERENCES [dbo].[Videos] ([idVideo]),
)
