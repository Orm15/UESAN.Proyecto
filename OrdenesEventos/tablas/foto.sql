CREATE TABLE [dbo].[foto]
(
	[idFoto] INT NOT NULL PRIMARY KEY identity, 
    [idServicios] INT NULL, 
    [CantidadFotos] INT NULL, 
    [nombrePersonaObjetivo] NCHAR(40) NULL, 
    [ubicacionFoto] NCHAR(30) NULL, 
    [canales] NCHAR(40) NULL, 
    [tipoFoto] NCHAR(40) NULL, 
    [nombre] NCHAR(40) NULL, 
    [link] NCHAR(40) NULL, 
    [fechaSubida] DATETIME NULL,
    FOREIGN KEY ([idServicios]) REFERENCES [dbo].[Servicios] ([idServicios])
)
