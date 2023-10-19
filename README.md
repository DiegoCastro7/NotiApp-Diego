# NotiApp-Diego
# API de Notificaciones en C#/.NET

Este README proporciona información sobre la creación de una API de notificaciones en C# utilizando el framework .NET. La API se desarrolla utilizando varios proyectos y dependencias para lograr un sistema completo de notificaciones. A continuación, se detallan las entidades clave involucradas en el proyecto y los pasos para su configuración.

La aplicación Noti-App está diseñada para mejorar la comunicación y la interacción en entornos académicos. Con esta herramienta, se ha creado una forma efectiva de mantener informados a estudiantes, profesores y personal administrativo sobre eventos, plazos, cambios en horarios y cualquier información relevante. Los usuarios pueden personalizar sus preferencias de notificación para recibir únicamente la información que necesitan. Además, la aplicación se integra sin problemas con los sistemas existentes de la universidad, lo que proporciona acceso a información en tiempo real. El objetivo principal de esta aplicación es facilitar la vida académica y garantizar que todos estén al tanto de lo que está sucediendo en el campus.

## Visualizacion grafica de la base de datos

![Alt text](/Resources/notiapp.png)

## Entidades

- **Auditoria**: Registra información de auditoría relacionada con las notificaciones.
- **BlockChain**: Implementa un sistema de registro y seguimiento de cambios seguros.
- **EstadoNotificacion**: Define los estados posibles de una notificación, como leída, no leída, en proceso, etc.
- **Formatos**: Representa diferentes formatos de notificaciones, como texto, HTML, multimedia, etc.
- **HiloRespuestaNotificacion**: Permite rastrear conversaciones y respuestas relacionadas con una notificación específica.
- **ModuloNotificaciones**: Representa módulos o áreas del sistema que pueden generar notificaciones.
- **ModulosMaestros**: Gestiona módulos principales dentro del sistema.
- **PermisosGenericos**: Define permisos de acceso a notificaciones y módulos.
- **Radicados**: Rastrea los radicados relacionados con notificaciones.
- **Rol**: Define roles de usuario con diferentes permisos y acceso a notificaciones.
- **SubModulos**: Se relaciona con los módulos maestros y define subáreas dentro de los módulos.
- **TipoNotificaciones**: Categoriza las notificaciones en diferentes tipos, como correo electrónico, notificaciones push, etc.
- **TipoRequerimiento**: Define tipos de requerimientos o solicitudes asociados con las notificaciones.

## Estructura del Proyecto

El proyecto se organiza en tres componentes principales:

1. **Core**: Biblioteca de clases que contiene las definiciones de las entidades y la lógica central de la aplicación. Aquí se define la estructura de datos y la lógica de negocios.
2. **Infrastructure**: Biblioteca de clases que gestiona aspectos de infraestructura, como el acceso a la base de datos, servicios de terceros, registro de auditoría, etc.
3. **ApiNotifications**: Aplicación web API que proporciona endpoints para interactuar con la API de notificaciones. Aquí se configuran las rutas, controladores y autenticación.

## Pasos de Creación del Proyecto

### Creación de Solución

```bash
dotnet new sln

```

### Creación de Proyecto Core

```bash
dotnet new classlib -o Core

```

### Creación de Proyecto Infrastructure

```bash
dotnet new classlib -o Infrastructure

```

### Creación de Proyecto Web API

```bash
dotnet new webapi -o ApiNotifications

```

### Agregar Proyectos a la Solución

```bash
dotnet sln add ApiNotifications
dotnet sln add Core
dotnet sln add Infrastructure

```

### Agregar Referencias entre Proyectos

Asegúrese de que los proyectos tengan las referencias necesarias para que funcionen correctamente. Las referencias se establecen desde el proyecto que contiene la referencia.

```bash
dotnet add reference ..\Infrastructure
dotnet add reference ..\Core

```

## Instalación de Paquetes

### Proyecto WebAPI

```bash
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 7.0.10
dotnet add package Microsoft.EntityFrameworkCore --version 7.0.10
dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.10
dotnet add package Microsoft.Extensions.DependencyInjection --version 7.0.0
dotnet add package System.IdentityModel.Tokens.Jwt --version 6.32.3
dotnet add package Serilog.AspNetCore --version 7.0.0
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection --version 12.0.1

```

### Proyecto Infrastructure

```bash
dotnet add package Pomelo.EntityFrameworkCore.MySql --version 7.0.0
dotnet add package Microsoft.EntityFrameworkCore --version 7.0.10
dotnet add package CsvHelper --version 30.0.1

```
## FUNCIONALIDAD DE LOS DTOS
### Auditoria:
`{
    "NombreUsuario" : "String",
    "DesAccion" : Int
}`

### Blockchain:
Necesitas tener elementos creados de:
1. Auditoria
2. Hilo Respuesta
3. Tipo Notificacion

`{
    "HashGenerado" : "String",
    "IdAuditoriaFk" : Int(IdAuditoria),
    "IdHiloRespuestaFk" : Int(IdHiloRespuesta),
    "IdNotificacionFk" : Int(IdNotificacion)
}`


### Estado Notificacion:
`{
    "NombreEstado" : "String"
}`


### Formato:
`{
    "NombreFormato" : "String"
}`


### Hilo Respuesta:
`{
    "NombreTipo" : "String"
}`


### Modulo Maestros:
`{
    "NombreModulo" : "String"
}`


### Modulo Notificicaciones:
Necesitas tener elementos creados de:
1. Tipo Notificacion
2. Radicado
3. Estado Notificacion
4. Hilo Respuesta
5. Formato
6. Requerimiento

`{
    "AsuntoNotificacion" : "String",
    "TextoNotificacion" : "String",
    "IdNotificacionFk" : Int(IdNotificacionFk),
    "IdEstadoNotificacionFk" : Int(IdEstadoNotificacionFk),
    "IdHiloRespuestaFk" : Int(IdHiloRespuestaFk),
    "IdFormatoFk" : Int(IdFormatoFk),
    "IdRequerimiento" : Int(IdRequerimiento)
}`


### Permisos Genericos:
`{
    "NombrePermiso" : "String"
}`


### Radicados:
`{
}`


### Rol:
`{
    "Nombre" : "String"
}`


### SubModulo:
`{
    "NombreSubmodulo" : "String"
}`


### Tipo Notificación:
`{
    "NombreTipo" : "String"
}`


### Tipo Requerimiento:
`{
    "Nombre" : "String"
}`

### Contribuidores:

Normalización de la base de datos:

* Jholver Pardo