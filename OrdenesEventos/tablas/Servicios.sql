CREATE TABLE [dbo].[Servicios]
(
	[idServicios] INT NOT NULL PRIMARY KEY identity, 
    [idEvento] INT NULL,
	[nombre] NCHAR(50) NULL, 
    [tipo] NCHAR(50) NULL,

    FOREIGN KEY ([idEvento]) REFERENCES [dbo].[Eventos] ([idEvento])
)
