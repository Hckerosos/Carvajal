/*CREACIÓN BASE DE DATOS*/
CREATE DATABASE [DbFacturacion]
GO

USE [DbFacturacion]
GO

CREATE TABLE dbo.Producto
	(
	IdProducto int NOT NULL identity(1,1),
	Detalle varchar(50) NOT NULL,
	Marca varchar(50) NOT NULL,
	Precio numeric(20, 0) NOT NULL,
	Stock int NOT NULL,
	PRIMARY KEY (IdProducto)
	)
GO
CREATE TABLE dbo.Cliente
	(
	IdCliente int NOT NULL identity(1,1),
	Nombre varchar(50) NOT NULL,
	Apellido varchar(50) NOT NULL,
	Direccion varchar(50) NOT NULL,
	Telefono varchar(50) NOT NULL,
	PRIMARY KEY (IdCliente)
	)
GO
CREATE TABLE dbo.Factura
	(
	IdFactura int NOT NULL identity(1,1),
	IdCliente int NOT NULL,
	Fecha datetime NOT NULL,
	Secuencia int NOT NULL
	PRIMARY KEY (IdFactura),
    FOREIGN KEY (IdCliente) REFERENCES dbo.Cliente(IdCliente)
	)
GO
CREATE TABLE dbo.DetalleFactura
	(
	IdDetalleFactura int NOT NULL identity(1,1),
    IdFactura int NOT NULL,
    IdProducto int NOT NULL,
	Precio numeric(20, 0) NOT NULL,
	Cantidad int NOT NULL,
	PRIMARY KEY (IdDetalleFactura),
    FOREIGN KEY (IdFactura) REFERENCES dbo.Factura(IdFactura),
    FOREIGN KEY (IdProducto) REFERENCES dbo.Producto(IdProducto)
	)

/*LLENAR DATOS*/
SET IDENTITY_INSERT [dbo].[Producto] ON 
GO
INSERT [dbo].[Producto] ([IdProducto], [Detalle], [Marca], [Precio], [Stock]) 
VALUES (1, 'Camiseta','Zara', CAST(1 AS Numeric(20, 0)), 6)
GO
INSERT [dbo].[Producto] ([IdProducto], [Detalle], [Marca], [Precio], [Stock]) 
VALUES (2, 'Pantalon','DZ', CAST(1 AS Numeric(20, 0)), 15)
GO
INSERT [dbo].[Producto] ([IdProducto], [Detalle], [Marca], [Precio], [Stock]) 
VALUES (3, 'Gorra','Forever one', CAST(1 AS Numeric(20, 0)), 30)
SET IDENTITY_INSERT [dbo].[Producto] OFF

SET IDENTITY_INSERT [dbo].[Cliente] ON 
GO
INSERT [dbo].[Cliente] ([IdCliente], [Nombre], [Apellido], [Direccion], [Telefono]) 
VALUES (1, 'Miguel','Rodriguez','av 70 # 66-84','3445623456')
GO
INSERT [dbo].[Cliente] ([IdCliente], [Nombre], [Apellido], [Direccion], [Telefono]) 
VALUES (2, 'Erick','Rojas','av 4 # 77-54','3455555556')
GO
INSERT [dbo].[Cliente] ([IdCliente], [Nombre], [Apellido], [Direccion], [Telefono]) 
VALUES (3, 'Victor','Brazo','av 24 # 67-44','3445623456')
SET IDENTITY_INSERT [dbo].[Cliente] OFF

SET IDENTITY_INSERT [dbo].[Factura] ON 
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Date], [Secuencia]) 
VALUES (1, 1, CAST(N'3001-10-20T20:26:15.000' AS DateTime), 1)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Date], [Secuencia]) 
VALUES (2, 3, CAST(N'3001-10-20T20:26:15.000' AS DateTime), 2)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Date], [Secuencia]) 
VALUES (3, 2, CAST(N'3001-10-20T20:26:15.000' AS DateTime), 3)
SET IDENTITY_INSERT [dbo].[Factura] OFF

SET IDENTITY_INSERT [dbo].[DetalleFactura] ON 
GO
INSERT [dbo].[DetalleFactura] ([IdDetalleFactura], [IdFactura], [IdProducto], [Precio], [Cantidad]) 
VALUES (1, 3, 2, CAST(1 AS Numeric(20, 0)), 3)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalleFactura], [IdFactura], [IdProducto], [Precio], [Cantidad]) 
VALUES (2, 2, 1, CAST(1 AS Numeric(20, 0)), 8)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalleFactura], [IdFactura], [IdProducto], [Precio], [Cantidad]) 
VALUES (3, 1, 3, CAST(1 AS Numeric(20, 0)), 2)
SET IDENTITY_INSERT [dbo].[DetalleFactura] OFF