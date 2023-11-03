create Procedure GetAllClientes
AS

SELECT 
CL.Id,
RazonSocial,
IdTipoCliente,
CTCL.TipoCliente,
FechaCreacion,
RFC

FROM DevLab.dbo.TblClientes CL INNER JOIN CatTipoCliente CTCL ON CL.IdTipoCliente = CTCL.Id