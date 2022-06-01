# curso-switcher-ort-tp
# Importante...
## Base de datos.
Las migraciones ya vienen en el proyecto, se deberá de ejecutar el comando `update-database` para aplicarlas y de ese modo que se cree un file llamado "database.db" en el root al cual podremos acceder y hacer pruebas.
> De hacer algún cambio en los modelos (a nivel diseño) se deberá de ejecutar el comando `add-migration nombre-de-la-migracion` para que estos luego puedan ser trazados y el ORM sepa como levantar la base en el proximo `update`

# Características y Funcionalidades

## Usuarios

El sistema cuenta con dos tipos de usuarios: Estudiantes y Administradores

En caso de que no tengan una cuenta creada, solo los estudiantes podran registrarse haciendo click en el enlace debajo del boton LOGIN que los llevará a la página de Registro.

En la pagina de Registro, se le pedirá al estudiante los siguientes datos:

- Seleccionar Carrera
- Seleccionar Sede
- Ingresar Nombre
- Ingresar Apellido
- Ingresar DNI
- Ingresar Email
- Ingresar contraseña

Se validará que no exista un usuario con el mismo DNI en la base de datos.

El alta de nuevos administradores solo será posible desde el backoffice a través de un usuario administrador, cuyas credenciales seran entregadas al dueño del sistema.

# Login

Ambos tipos de usuarios realizarán el login con su DNI y contraseña.

Para el caso de los estudiantes, si logran loguearse con exito serán redirigidos a su dashboard.

Para el caso de los administradores, si logran loguearse con exito serán redirigidos al back-office.

# Dashboard

Una vez logueado, el estudiante verá un dashboard donde se visualizará el estado de sus solicitudes de cambio de curso en caso de que haya realizado alguna en todo su historial.

El estudiante podrá cancelar las solicitudes que tenga pendientes desde el botón "Cancelar" perteneciente a la solicitud en cuestión.

En caso de que el estudiante nunca haya realizado una solicitud de cambio de curso, se indicará en una leyenda junto a un enlace para crear su primer solicitud de cambio de curso.

En la parte superior izquierda, podrá observar una barra de navegación con los items: "Home" - "Editar perfil" - "Salir".
El item "Home" sera un redirect al dashboard del estudiante.
El item "Editar perfil" le permitirá al estudiante modificar:
 - Su curso actual
 - Su Sede
 - Su carrera
 - Su contraseña

El item "Salir" cerrará la sesión del estudiante.

# Solicitud de cambio de curso

La solicitud de cambio de curso requiere 2 campos para ser creada:
- Curso actual
- Curso deseado

En el caso de que el usuario ya tenga seteado un curso actual (puede agregarlo desde la sección "Editar Perfil"), el mismo aparecerá pre-cargado.
En el caso de que el usuario no tenga seteado un curso, debera seleccionar un curso de la lista ofrecida (estos dependeran de la Sede y Carrera, datos obtenidos al momento del registro).

El estudiante deberá seleccionar su curso deseado de la lista de cursos disponibles para el cambio (apareceran los pertenecientes a su Sede y Carrera filtrados tambien por cuatrimestre, el mismo perteneciente a su curso actual).

La solicitud será creada una vez que el estudiante haga click sobre el botón "Enviar solicitud".

Las solicitudes tienen 4 estados posibles:
- APROBADA (una vez que un usuario administrador aprueba la solicitud de cambio)
- RECHAZADA (una vez que un usuario administrador rechaza la solicitud de cambio)
- PENDIENTE_DE_MATCH (desde que es creada hasta que hace match con otra solicitud)
- PENDIENTE_DE_APROBACION (desde que hace match hasta que es aprobada o rechazada por un usuario administrador)

# Sistema de notificación por email

El estudiante será notificado por email en los siguientes escenarios:
- Cuando su solicitud es creada
- Cuando su solicitud encuentra match y pasa al estado PENDIENTE_DE_APROBACION
- Cuando su solicitud es aprobada
- Cuando su solicitud es rechazada
- Cuando crea su cuenta a modo de bienvenida
- Cuando realiza un cambio de contraseña
