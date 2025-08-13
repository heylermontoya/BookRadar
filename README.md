#  Book Radar – Prueba Técnica

Este proyecto es el resultado de la prueba técnica solicitada, cuyo objetivo es implementar una solución funcional que permita gestionar un catálogo de libros y autores.

Aplicación MVC que permite buscar libros por autor usando la API pública de OpenLibrary, mostrar los resultados y guardar el historial de búsquedas en SQL Server. El objetivo es demostrar dominio de ASP.NET Core MVC, consumo de APIs, Entity Framework Core, vistas Razor, validación y buenas prácticas básicas.

- Características principales

Búsqueda por autor contra openlibrary.org.

Vista de resultados con Título, Año de publicación y Editorial.

Historial persistido en SQL Server mediante EF Core.

Regla de negocio: evitar guardar búsquedas repetidas en 1 minuto.


- Datos técnicos de la integración (OpenLibrary)

Endpoint consultado: https://openlibrary.org/search.json?author={AUTOR}

Se mapea un subconjunto de campos en LibroApiResult → LibroItem.

Se limitan los resultados mostrados (p. ej. Take(100)).

Se guarda en HistorialBusquedas con la regla anti-duplicado por (autor, título, ventana 1 min).

---

##  Pasos para ejecutar el proyecto

A continuación se explican **todos los pasos** para poder ejecutar el proyecto en un equipo nuevo, asegurando que el entorno de desarrollo o evaluación sea replicable.

### 1 Requisitos previos

Antes de iniciar, asegúrate de tener instalado:

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [SQL Server 2019+](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) o Docker Desktop
- [Git](https://git-scm.com/)

---

### 2 Clonar el repositorio

```bash
git clone https://github.com/heylermontoya/BookRadar.git
cd book-radar

---

### 3 Base de datos

Tener una instancia de **SQL Server** con un usuario con permisos suficientes para crear bases de datos, por ejemplo un usuario con el rol sysadmin.

Edita el archivo `appsettings.json` para ajustar la cadena de conexión a SQL Server:

    ```json
    "StringConnection": "Server=localhost\\SQLEXPRESS;Database=BookRadarDB;User Id=sa;Password=12345;TrustServerCertificate=True"
    ```

Ejecuta las migraciones de **Entity Framework** para crear la base de datos:

    a) Instala el CLI de **EF Core**:
    ```bash
    dotnet tool install --global dotnet-ef
    ```

    c) Aplica la migración y crea la base de datos:
    ```bash
    dotnet ef database update 
    ```
---

### 4 Poner a correr la aplicación

    La aplicación estará disponible en el puerto `7004`.

    Con lo anterior ya deberia de poder ver la aplicacion funcionando correctamente en su entorno local.

---

### 6 Mejoras pendientes

- IHttpClientFactory con políticas de resiliencia vía Polly.

- Paginación en Resultados e Historial para cargas grandes.

- Caching de resultados por autor (ej. MemoryCache o distribuido con Redis) para reducir llamadas repetidas.

- Pruebas unitarias (xUnit/MSTest) y tests de integración con WebApplicationFactory.

- Búsqueda avanzada (por título, año, editorial) y filtros client-side.