CREATE TABLE [dbo].[CircuitoCerrado]
(
	[IdCircuitoCerrado] INT NOT NULL PRIMARY KEY identity, 
    [idServicio] INT NULL, 
    [Guardar] NCHAR(10) NULL, 
    [Link] NCHAR(100) NULL, 
    [NumeroCamaras] NCHAR(10) NULL, 
    [NumeroAngulos] NCHAR(10) NULL, 
    [Angulos] NCHAR(100) NULL, 
    [Estado] NCHAR(15) NULL , 
     FOREIGN KEY ([idServicio]) REFERENCES [dbo].[Servicios] ([idServicios]),
)
