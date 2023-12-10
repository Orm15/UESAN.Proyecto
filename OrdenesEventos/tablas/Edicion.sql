CREATE TABLE [dbo].[Edicion]
(
	[idEdicion] INT NOT NULL PRIMARY KEY, 
    [idVideo] INT NULL, 
    [Musica] NCHAR(30) NULL, 
    [nombre] NCHAR(40) NULL,
    [descripción] NCHAR(100) NULL, 
    [estado] NCHAR(20) NULL, 
    FOREIGN KEY ([idVideo]) REFERENCES [dbo].[videos] ([idVideo]),
)
