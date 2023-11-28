CREATE TABLE [dbo].[Usuarios]
(
	[idUsuario] INT NOT NULL PRIMARY KEY identity, 
    [correo] NVARCHAR(50) NULL, 
    [nombre] NVARCHAR(50) NULL, 
    [area] NVARCHAR(50) NULL, 
    [tipo] NVARCHAR(50) NULL, 
    [estado] NCHAR(20) NULL, 
    [contra] NVARCHAR(50) NULL
)
