CREATE TABLE [dbo].[videos]
(
	[idVideo] INT NOT NULL PRIMARY KEY identity, 
    [fechaSubida] DATETIME NULL,
    [nombre] NCHAR(40) NULL, 
    [link] NCHAR(100) NULL, 
    [nombreObjetivo] NCHAR(50) NULL, 
    [lugarFilmacion] NCHAR(50) NULL, 
    [Edicion] INT NULL,
    [idServicio] INT NULL, 
    FOREIGN KEY ([idServicio]) REFERENCES [dbo].[Servicios] ([idServicios]),

    
)
