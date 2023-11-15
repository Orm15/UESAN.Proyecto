CREATE TABLE [dbo].[videos]
(
	[idVideo] INT NOT NULL PRIMARY KEY identity, 
    [idServicio] INT NULL, 
    [fechaSubida] DATETIME NULL, 
    [nombre] NCHAR(40) NULL, 
    [link] NCHAR(100) NULL, 
    [nombreObjetivo] NCHAR(50) NULL, 
    [lugarFilmacion] NCHAR(50) NULL,

    FOREIGN KEY ([idServicio]) REFERENCES [dbo].[Servicios] ([idServicios])
)
