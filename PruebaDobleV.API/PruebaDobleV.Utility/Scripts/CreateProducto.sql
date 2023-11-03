USE [DevLab]
GO
/****** Object:  StoredProcedure [dbo].[CreateProducto]    Script Date: 3/11/2023 11:07:54 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[CreateProducto]
(
@nombreProducto varchar(50),
@imagenProducto Image,
@precioUnitario decimal(18,2),
@ext varchar(5)
)
AS
INSERT INTO CatProductos 
VALUES
(
@nombreProducto,
@imagenProducto,
@precioUnitario,
@ext
)
