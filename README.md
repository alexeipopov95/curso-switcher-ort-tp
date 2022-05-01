# curso-switcher-ort-tp
# Importante...
## Base de datos.
Las migraciones ya vienen en el proyecto, se deberá de ejecutar el comando `update-database` para aplicarlas y de ese modo que se cree un file llamado "database.db" en el root al cual podremos acceder y hacer pruebas.
> De hacer algún cambio en los modelos (a nivel diseño) se deberá de ejecutar el comando `add-migration nombre-de-la-migracion` para que estos luego puedan ser trazados y el ORM sepa como levantar la base en el proximo `update`
