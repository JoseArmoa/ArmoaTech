use master
GO

CREATE DATABASE [ArmoaTech]
GO

USE ArmoaTech
GO

CREATE TABLE Categorias
(
idCategoria int identity(1,1) primary key,
Descripcion varchar(50)
)
GO

CREATE TABLE Marcas
(
idMarcas int identity(1,1) primary key,
Descripcion varchar(50)
)
GO

CREATE TABLE Productos
(
codProducto nchar(8),
CONSTRAINT PK_Producto primary key(codProducto),
Nombre varchar(50),

Descripcion varchar(150),

idCategoria int foreign key references Categorias(idCategoria),
idMarca int foreign key references Marcas(idMarcas),
precio decimal default 0,

imageurl varchar(100),

estado bit default 1
)
GO

CREATE TABLE Reparaciones
(
codReparacion nchar(8) primary key not null,
NombreCliente varchar(50) not null,
TelefonoCliente varchar(15) null,
emailCliente varchar(50) null,

fechaIngreso date not null,
fechaRetiro date null,

servicio varchar(50) not null,
estado varchar(50) not null,
ubicacion varchar(50),

precio decimal default 0
)
GO

CREATE TABLE Observaciones
(
idObservacion int identity(1,1) primary key,
codReparacion nchar(8) foreign key references Reparaciones(codReparacion),
detalle varchar(150),
imgurl varchar(100)
)
GO
