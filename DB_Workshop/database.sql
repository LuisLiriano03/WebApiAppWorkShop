

create database DBGestionProyectosUsuarios 

use DBGestionProyectosUsuarios

go

create table Rol(
IdRol int primary key identity(1,1),
Nombre varchar(50),
FechaRegistro datetime default getdate()
)

create table Menu(
IdMenu int primary key identity(1,1),
Nombre varchar(50),
Icono varchar(50),
UrlMenu varchar(50)
)

create table MenuRol(
IdMenuRol int primary key identity(1,1),
IdMenu int references Menu(IdMenu),
IdRol int references Rol(IdRol)
)

create table Usuario(
IdUsuario int primary key identity(1,1),
NombreCompleto varchar(100),
Correo varchar(40),
IdRol int references Rol(IdRol),
Clave varchar(40),
EsActivo bit default 1,
FechaRegistro datetime default getdate()
)

create table Proyecto(
IdProyecto int primary key identity(1,1),
Descripcion varchar(200),
IdUsuario int references Usuario(IdUsuario),
FechaRegistro datetime default getdate()
)
