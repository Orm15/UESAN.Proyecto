CREATE TABLE [dbo].[foto]
(
	[idFoto] INT NOT NULL PRIMARY KEY identity, 
    [ubicacionFoto] NCHAR(30) NULL, 
    [canales] NCHAR(40) NULL, 
    [tipoFoto] NCHAR(40) NULL, 
    [nombre] NCHAR(40) NULL, 
    [link] NCHAR(40) NULL, 
    [fechaSubida] DATETIME NULL,
)
