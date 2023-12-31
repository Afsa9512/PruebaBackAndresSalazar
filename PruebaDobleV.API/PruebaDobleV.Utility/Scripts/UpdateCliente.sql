USE [DevLab]
GO
/****** Object:  StoredProcedure [dbo].[CreateCliente]    Script Date: 3/11/2023 12:17:45 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[UpdateCliente]
(
@Id int,
@RazonSocial varchar(200),
@IdTipoCliente int,
@FechaCreacion DATE,
@RFC varchar(50)
)
AS
UPDATE TblClientes SET RazonSocial = @RazonSocial,IdTipoCliente=@IdTipoCliente,FechaCreacion=@FechaCreacion,RFC=@RFC
WHERE Id = @Id