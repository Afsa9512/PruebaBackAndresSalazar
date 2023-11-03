CREATE PROCEDURE CreateDetalleFactura
(
@idFactura int,
@idProducto int,
@cantidadDeProducto int,
@precioUnitario decimal(18,2),
@subTotal decimal(18,2),
@notas varchar(200)
)
AS
insert into TblDetallesFactura (IdFactura,IdProducto,CantidadDeProducto,PrecioUnitarioProducto,SubtotalProducto,Notas)
VALUES
(
@idFactura,
@idProducto,
@cantidadDeProducto,
@precioUnitario,
@subTotal,
@notas
)
