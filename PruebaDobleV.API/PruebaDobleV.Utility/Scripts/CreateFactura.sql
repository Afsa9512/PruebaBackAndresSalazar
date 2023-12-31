USE [DevLab]
GO
/****** Object:  StoredProcedure [dbo].[CreateFactura]    Script Date: 2/11/2023 9:33:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[CreateFactura]
(
@FechaFactura Datetime,
@IdCliente int,
@NumeroFactura int,
@NumeroTotalArticulos int,
@SubTotalFactura decimal(18,2),
@TotalImpuesto decimal(18,2),
@TotalFactura decimal(18,2)
)
AS
BEGIN
DECLARE @InsertedId int;

INSERT INTO TblFacturas (FechaEmisionFactura,IdCliente,NumeroFactura,NumeroTotalArticulos,SubTotalFactura,TotalImpuesto,TotalFactura)
VALUES
(
@FechaFactura,
@IdCliente,
@NumeroFactura,
@NumeroTotalArticulos,
@SubTotalFactura,
@TotalImpuesto,
@TotalFactura
)
SET @InsertedId = SCOPE_IDENTITY();

SELECT @InsertedId AS 'IdFactura'; -- Devuelve el ID insertado

END