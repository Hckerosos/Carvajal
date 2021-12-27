/*PRECIO DE TODOS LOS PRODUCTOS*/
SELECT
Precio
FROM [DbFacturacion].[dbo].[Producto]

/*PRECIO DE TODOS LOS PRODUCTOS STOCK MENOR A 6*/
SELECT
Precio
FROM [DbFacturacion].[dbo].[Producto] where Stock <= 6

/*PRECIO TODOS LOS CLIENTES QUE FACTURARON EN RANGO FECHA*/
SELECT 
*
FROM ((([DbFacturacion].[dbo].[Cliente] C
INNER JOIN [DbFacturacion].[dbo].[Factura] F ON C.IdCliente = F.IdCliente)
INNER JOIN [DbFacturacion].[dbo].[DetalleFactura] D ON F.IdFactura = D.IdFactura)
INNER JOIN [DbFacturacion].[dbo].[Producto] P ON P.IdProducto = D.IdProducto)
WHERE F.Fecha BETWEEN '2000-01-01' AND '2000-05-25';

/*PRECIO DE TODOS LOS PRODUCTOS STOCK MENOR A 6*/
SELECT 
SUM(D.Precio) Total_Ventas
FROM (([DbFacturacion].[dbo].[Factura] F 
INNER JOIN [DbFacturacion].[dbo].[DetalleFactura] D ON F.IdFactura = D.IdFactura)
INNER JOIN [DbFacturacion].[dbo].[Producto] P ON P.IdProducto = D.IdProducto)
WHERE F.Fecha > '3001-10-20';
