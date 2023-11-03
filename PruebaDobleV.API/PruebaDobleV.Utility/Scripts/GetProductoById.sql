create procedure GetProductoById
(
@IdProducto int
)
AS
select
Id,
NombreProducto,
ImagenProducto,
PrecioUnitario,
Ext

from CatProductos where Id = @IdProducto
