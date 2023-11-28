CREATE TABLE [dbo].[Stream]
(
	[idStream] INT NOT NULL PRIMARY KEY, 
    [idServicios] INT NULL,
	FOREIGN KEY ([idServicios]) REFERENCES [dbo].[Servicios] ([idServicios])
)
