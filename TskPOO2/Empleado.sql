CREATE TABLE [dbo].[Empleado]
(
	[Id] INT identity (1, 1) NOT NULL PRIMARY KEY, 
    [Nombre] NVARCHAR(MAX) NOT NULL, 
    [Apellido] NVARCHAR(MAX) NOT NULL, 
    [FechaIngreso] DATETIME NOT NULL, 
    [Salario] FLOAT NOT NULL
)
