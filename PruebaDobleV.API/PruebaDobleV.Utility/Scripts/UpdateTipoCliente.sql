USE [DevLab]
GO
/****** Object:  StoredProcedure [dbo].[CreateTipoCliente]    Script Date: 3/11/2023 12:19:43 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[UpdateTipoCliente]
(
@Id int,
@TipoCliente varchar(50)
)
AS
Update CatTipoCliente SET TipoCliente = @TipoCliente
WHERE Id = @Id