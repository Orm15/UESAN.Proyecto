﻿CREATE TABLE [dbo].[ServicioFotos]
(
	[IdServicioFotos] INT NOT NULL PRIMARY KEY identity, 
    [IdServicio] INT NULL, 
    [CantidadFotos] NCHAR(10) NULL, 
    [Tipo] NCHAR(10) NULL, 
    [PesonaObjetivo] NCHAR(10) NULL,
    [Canales] NCHAR(40) NULL, 
    [Link] NCHAR(200) NULL, 
    [estado] NCHAR(20) NULL, 
    FOREIGN KEY ([idServicio]) REFERENCES [dbo].[Servicios] ([idServicios])
)
