Create procedure GetAllDetallesFactura
(
@IdFactura int
)
AS
select
DF.Id,
IdFactura,
IdProducto,
CantidadDeProducto,
PrecioUnitarioProducto,
SubtotalProducto,
Notas,
ImagenProducto

from TblDetallesFactura DF INNER JOIN CatProductos P ON DF.IdProducto = P.Id where DF.IdFactura = @IdFactura