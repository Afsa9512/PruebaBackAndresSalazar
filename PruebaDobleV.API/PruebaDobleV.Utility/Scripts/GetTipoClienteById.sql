create procedure GetTipoClienteById
(
@IdTipoCliente int
)
AS
select 
Id,
TipoCliente
from CatTipoCliente where Id = @IdTipoCliente