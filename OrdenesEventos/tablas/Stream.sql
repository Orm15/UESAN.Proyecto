CREATE TABLE [dbo].[Stream]
(
	[idStream] INT NOT NULL PRIMARY KEY identity, 
    [idServicios] INT NULL,
	[Plataforma] NCHAR(20) NULL, 
    [Cuenta] NCHAR(20) NULL, 
    [Contacto_Cuenta] NCHAR(20) NULL, 
    [Num_Cam] INT NULL, 
    [Angulo] NCHAR(50) NULL, 
    [Estado] NCHAR(10) NULL, 
    FOREIGN KEY ([idServicios]) REFERENCES [dbo].[Servicios] ([idServicios])
)
