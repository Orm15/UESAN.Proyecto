CREATE TABLE [dbo].[ServicioFotos]
(
	[IdServicioFotos] INT NOT NULL PRIMARY KEY, 
    [IdServicio] INT NULL, 
    [IdFotos] INT NULL, 
    [CantidadFotos] NCHAR(10) NULL, 
    [Tipo] NCHAR(10) NULL, 
    [PesonaObjetivo] NCHAR(10) NULL,
    FOREIGN KEY ([idServicio]) REFERENCES [dbo].[Servicios] ([idServicios]),
    FOREIGN KEY ([idFotos]) REFERENCES [dbo].[Foto] ([idFoto])

)
