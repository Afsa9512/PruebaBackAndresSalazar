Create procedure GetAllFacturas
AS
select
F.Id,
FechaEmisionFactura,
IdCliente,
NumeroFactura,
NumeroTotalArticulos,
SubTotalFactura,
TotalImpuesto,
TotalFactura,
C.RazonSocial

from TblFacturas F INNER JOIN TblClientes C ON F.IdCliente = C.Id
