create procedure CreateCliente
(
@RazonSocial varchar(200),
@IdTipoCliente int,
@FechaCreacion DATE,
@RFC varchar(50)
)
AS
Insert into TblClientes (RazonSocial,IdTipoCliente,FechaCreacion,RFC) values 
(
@RazonSocial,
@IdTipoCliente,
@FechaCreacion,
@RFC
)