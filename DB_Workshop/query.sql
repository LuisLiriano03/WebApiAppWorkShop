use DBGestionProyectosUsuarios

insert into Rol(Nombre) values
('Administrador'),
('Usuario')

insert into Usuario(NombreCompleto,Correo,IdRol,Clave) values
('Juan Lopez','juanlopez23@gmail.com',1,'1234567')

insert into Usuario(NombreCompleto,Correo,IdRol,Clave) values
('Carlos Sanchez','sanchez98@gmail.com',2,'1234567')

insert into Menu(Nombre,Icono,UrlMenu) values
('Asignacion Proyecto', 'assignment_ind' , '/pages/asignacion_proyectos'),
('Usuarios', 'group' , '/pages/usuarios'),
('Proyectos Asignados', 'assignment' , '/pages/proyectos_asignados')

insert into MenuRol(IdMenu,IdRol) values
(1,1),
(2,1),
(3,1)

insert into MenuRol(IdMenu,IdRol) values(3,2)

insert into proyecto(Descripcion, IdUsuario) values
('Hacer una soluccion en php que sume dos numeros enteros.', 2)
