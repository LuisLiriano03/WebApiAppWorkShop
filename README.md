# API del Sistema de Gestión de Proyectos y Usuarios

Este proyecto consiste en una API desarrollada con ASP.NET Core Web API 7.0, diseñada para gestionar proyectos y usuarios. La arquitectura del proyecto sigue un enfoque basado en capas, utilizando bibliotecas de clase para organizar y separar las responsabilidades.

**Capas del Proyecto**

1. **ProyectoGestion.API:**

	- **Proyecto principal:** Implementa la API utilizando ASP.NET Core Web API 7.0.

2. **GestionProyectos.BLL:**

	- **Capa de Negocio:** Gestiona los servicios y define interfaces para facilitar el manejo en los controladores de la API.

3. **GestionProyectos.DAL:**

	- **Capa de Datos:**  Se encarga del manejo del DbContext y los repositorios genéricos para interactuar con la base de datos.

4. **GestionProyectos.DTO:**

	- **Objetos de Transferencia de Datos:** Contiene clases que representan los objetos de datos utilizados en la comunicación entre las capas.

5. **GestionProyectos.IOC:**

	- **Inversión de Control de Dependencias:** Gestiona la inyección de dependencias para facilitar la modularidad y la prueba unitaria.

6. **GestionProyectos.Model:**

	- **Modelos de la Base de Datos:** Define las entidades de la base de datos y se migra mediante Entity Framework.

7. **GestionProyectos.Utility:**

	- **Utilidades:** Contiene utilidades a nivel general, haciendo uso de AutoMapper para el mapeo entre DTO y modelos.

**Configuración de la Base de Datos**

Para configurar la base de datos, se utiliza el siguiente comando de Entity Framework:

	 Scaffold-DbContext "Server=(local); DataBase= DBGestionProyectosUsuarios; Trusted_Connection=True; TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer


**Endpoints**

1. **Menu**

	- **GET:** Obtiene los menús a los que tiene acceso un usuario (administrador o no) mediante el ID de usuario ingresado.

2. **Proyecto**

	- **GET:** Obtiene una lista de todos los proyectos existentes.
	
	- **GET con idUsuario**: Obtiene los proyectos asignados a un usuario específico mediante su ID.
	
	- **POST:** Guarda nuevos proyectos.
	
	- **PUT:** Edita proyectos existentes, permitiendo cambios en la descripción y el usuario asignado.
	
	- **DELETE:** Elimina un proyecto según el ID proporcionado.
	

3. **Rol**

	- **GET:** Obtiene la lista de roles existentes.

4. **Usuario**

	- **GET:** Obtiene la lista de todos los usuarios existentes.
	
	- **POST (Iniciar Sesión):** Valida el inicio de sesión y devuelve los datos del usuario si las credenciales son correctas.
	
	- **POST (Guardar Usuario):** Guarda nuevos usuarios.
	
	- **PUT:** Edita usuarios existentes.
	
	- **DELETE:** Elimina un usuario según el ID proporcionado.

**Documentación**

La API está documentada mediante Swagger para facilitar su comprensión y prueba.

**Características del Proyecto**

1. **Gestión de Proyectos:**

	- Permite la creación, edición y eliminación de proyectos, así como la asignación de usuarios a proyectos específicos.

1. **Autenticación de Usuario:**

	-  Proporciona un sistema de autenticación que valida las credenciales del usuario al iniciar sesión.

1. **Capas Organizadas:**

	-  El proyecto sigue un enfoque basado en capas para una mejor organización y mantenibilidad del código.

1. **Inyección de Dependencias:**

	- Utiliza Inversión de Control de Dependencias para mejorar la modularidad y facilitar las pruebas unitarias.

1. **Documentación con Swagger:**

	-  La API está documentada con Swagger para una fácil comprensión y prueba de los endpoints.

![Anotación 2024-01-26 160743](https://github.com/LuisLiriano03/WebApiAppWorkShop/assets/89108238/b3da82b5-2b01-4594-b858-73f36ca1f733)

