USE [DevLab]
GO
/****** Object:  StoredProcedure [dbo].[UpdateProducto]    Script Date: 3/11/2023 3:22:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[UpdateProducto]
(
@idProducto int,
@nombreProducto varchar(50),
@imagenProducto Image = null,
@precioUnitario decimal(18,2),
@ext varchar(5)
)
AS
UPDATE CatProductos set NombreProducto = @nombreProducto, ImagenProducto = @imagenProducto, PrecioUnitario = @precioUnitario, ext = @ext 

WHERE Id = @idProducto