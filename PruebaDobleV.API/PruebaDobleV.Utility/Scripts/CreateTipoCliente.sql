create procedure CreateTipoCliente
(
@TipoCliente varchar(50)
)
AS
Insert into CatTipoCliente (TipoCliente)
VALUES
(
@TipoCliente
)