CREATE TABLE [dbo].[Table]
(
	[Id] INT IDENTITY (1,1) NOT NULL PRIMARY KEY, 
    [Id_Proyecto] INT NOT NULL, 
    [Id_Empleado] INT NOT NULL, 
    CONSTRAINT [FK_Proyecto] FOREIGN KEY ([Id_Proyecto]) REFERENCES [Proyecto]([Id]),
	CONSTRAINT [FK_Empleado] FOREIGN KEY ([Id_Empleado]) REFERENCES [Empleado]([Id])
)
