USE [DevLab]
GO
/****** Object:  StoredProcedure [dbo].[GetAllFacturas]    Script Date: 2/11/2023 1:16:24 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetFacturaById]
(
@IdFactura int
)
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

from TblFacturas F INNER JOIN TblClientes C ON F.IdCliente = C.Id where F.Id = @IdFactura
