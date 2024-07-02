# KSP.BiblioNet

## Descripción
Este es el backend en .Net del proyecto KSP.BiblioNet.

## Requisitos
- Visual Studio 2022
- .Net 8
- Docker
- Docker Compose

## Instrucciones para levantar el proyecto
	
	1. Levantar contenedor con "docker-compose.yml, esto crará una instanciad de BD de SQL Server en el puerto 1433 (ya configurado en appsettings.json de proyecto).

	2. Ejecutar script "CREAR-POBLAR-BD_v1.0.0.sql" para crear y poblar la base de datos.

	3. Abrir solución "KSP.BiblioNet" y ejecutar. 

	4. Opcionalmente se incluye el archivo "API's KSP BiblioNet.postman_collection.json" para importar y realizar las peticiones con POSTMAN.
