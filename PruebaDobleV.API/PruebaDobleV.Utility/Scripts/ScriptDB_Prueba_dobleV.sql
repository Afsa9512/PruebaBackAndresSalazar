create database DevLab

use DevLab

create table CatTipoCliente(
Id int primary key identity (1,1),
TipoCliente varchar(50)
)

create table CatProductos(
Id int primary key identity (1,1),
NombreProducto varchar(50),
ImagenProducto image,
PrecioUnitario decimal(18,2),
Ext varchar(5)
)

create table TblClientes(
Id int primary key identity (1,1),
RazonSocial varchar(200),
IdTipoCliente int foreign key references CatTipoCliente(Id),
FechaCreacion Date,
RFC varchar(50)
)

create table TblFacturas(
Id int primary key identity (1,1),
FechaEmisionFactura datetime,
IdCliente int foreign key references TblClientes(Id),
NumeroFactura int,
NumeroTotalArticulos int,
SubTotalFactura decimal(18,2),
TotalImpuesto decimal(18,2),
TotalFactura decimal(18,2)
)

create table TblDetallesFactura(
Id int primary key identity (1,1),
IdFactura int foreign key references TblFacturas(Id),
IdProducto int foreign key references CatProductos(Id),
CantidadDeProducto int,
PrecioUnitarioProducto decimal(18,2),
SubtotalProducto decimal(18,2),
Notas varchar(200)
)