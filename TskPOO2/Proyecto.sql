CREATE TABLE [dbo].[Proyecto]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Nombre] NVARCHAR(MAX) NOT NULL, 
    [Descripcion] NVARCHAR(MAX) NOT NULL, 
    [FechaInicio] DATETIME NOT NULL, 
    [FechaFinal] DATETIME NOT NULL, 
    [Presupuesto] FLOAT NOT NULL, 
    [DEVs] INT NOT NULL, 
    [QAs] INT NOT NULL
)
