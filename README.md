# Tecnológico de Software
- **Arquitectura de Software**
- **Alumno:** Euruviel Marquez Martinez 
- **Docente:** Jorge Pedrozo Romero
- **Fecha:** 22/05/2026
- **Actividad:** Actividad #10 – Práctica .NET: Crear solución multi-proyecto

---

## Descripción

**AnimeVault** es una aplicación web desarrollada con **ASP.NET Core MVC** que permite gestionar un catálogo personal de anime. Los usuarios pueden explorar series, filtrarlas por género, ordenarlas por calificación o año, dejar comentarios y administrar su colección personal.

El proyecto aplica principios de **arquitectura en capas**, separando responsabilidades entre dominio, aplicación, infraestructura y presentación.

---

## Arquitectura

El proyecto sigue una **arquitectura de N capas**:

```
CatalogoApp/
├── Catalogo.Domain/              
│   ├── Models/
│   │   ├── Item.cs               
│   │   ├── Usuario.cs            
│   │   └── Comentario.cs        
│   └── Interfaces/
│       └── IItemRepository.cs   
│
├── Catalogo.Application/         
│   └── Services/
│       ├── ItemService.cs        
│       ├── UsuarioService.cs     
│       └── ComentarioService.cs 
│
├── Catalogo.Infrastructure/      
│   └── Repositories/
│       └── JsonItemRepository.cs 
│
└── Catalogo.Presentation/        
    ├── Controllers/
    │   ├── HomeController.cs
    │   ├── CatalogoController.cs
    │   └── AuthController.cs
    ├── Views/
    │   ├── Home/
    │   ├── Catalogo/
    │   └── Auth/
    └── wwwroot/
        └── css/site.css
```

---

##  Funcionalidades

| Funcionalidad | Descripción |
|---|---|
|  Catálogo visual | Tarjetas con portada, badge de estado y calificación |
|  Filtro por género | Filtra animes por categoría en tiempo real |
|  Ordenamiento | Ordena por calificación, año o título |
|  Agregar anime | Formulario completo con URL de portada |
|  Editar anime | Edición de todos los campos del anime |
|  Eliminar anime | Eliminación con confirmación |
|  Vista de detalle | Página completa con toda la información |
|  Comentarios | Sistema de reseñas con calificación por anime |
|  Login / Registro | Autenticación con usuario, email y contraseña |
|  Página de inicio | Hero, estadísticas y top 3 mejor calificados |
|  Responsive | Adaptable a diferentes tamaños de pantalla |

---

##  Tecnologías utilizadas

| Tecnología | Versión | Uso |
|---|---|---|
| C# | 12 | Lenguaje principal |
| ASP.NET Core MVC | .NET 9 | Framework web |
| JSON | — | Persistencia de datos |
| Git + GitHub | — | Control de versiones |


---


##  Persistencia de datos

Los datos se almacenan en archivos **JSON** dentro de `Controllers/Data/`:

| Archivo | Contenido |
|---|---|
| `items.json` | Catálogo de animes |
| `usuarios.json` | Usuarios registrados |
| `comentarios.json` | Comentarios por anime |

---

##  Capturas de pantalla

###  Página de inicio
> Hero con estadísticas y top 3 mejor calificados

<img width="1919" height="1064" alt="Captura de pantalla 2026-05-22 183511" src="https://github.com/user-attachments/assets/99ffde95-8062-4ec2-9b34-351b0720b513" />


###  Catálogo
> Cuadrícula de tarjetas con portadas, filtros y ordenamiento

<img width="1919" height="1079" alt="Captura de pantalla 2026-05-22 183526" src="https://github.com/user-attachments/assets/f8ddee5c-7882-4f52-85e1-5645b799afdf" />


###  Vista de detalle
> Información completa del anime con sección de comentarios

<img width="1919" height="1050" alt="Captura de pantalla 2026-05-22 183702" src="https://github.com/user-attachments/assets/a6c77daa-1015-457a-9101-81cda9e15d43" />



###  Login y Registro
> Formularios de autenticación con diseño anime

<img width="1919" height="1034" alt="Captura de pantalla 2026-05-22 183556" src="https://github.com/user-attachments/assets/294d256a-aa01-48b3-8f57-ecc5f153ebb8" />


---


## Principios aplicados

| Principio | Aplicación |
|---|---|
| **SRP** — Single Responsibility | Cada clase tiene una única responsabilidad (Service, Repository, Controller separados) |
| **DIP** — Dependency Inversion | `IItemRepository` desacopla la infraestructura del dominio |
| **OCP** — Open/Closed | Se pueden agregar nuevos repositorios (SQL, MongoDB) sin modificar la lógica de negocio |
| **Inyección de dependencias** | Servicios registrados en `Program.cs` y resueltos automáticamente |
| **Arquitectura en capas** | Separación clara entre Domain, Application, Infrastructure y Presentation |

---

##  Declaración de uso de Inteligencia Artificial

| Campo | Detalle |
|---|---|
| **Nombre del estudiante** | Euruviel Marquez Martinez |
| **IA utilizada** | Claude  |
| **Fecha de uso** | 20/05/2026 |
| **Propósito** | Corrección de errores|

### Prompt utilizado:
- *"Okey estoy haciendo un proyecto pero me marcan muchos errores, puedes ayudarme a solucionarlos"*

### Respuesta en crudo (raw):

Veo tu proyecto CatalogoApp en Visual Studio con 25 errores. Por la imagen puedo identificar los principales problemas:
Errores visibles:

CS0246 - ErrorViewModel no encontrado (falta using o referencia)
CS1002 - Se esperaba ;
CS1022 - Se esperaba definición de tipo o fin de archivo
CS0103 - jsonPath no existe en el contexto actual
CS1061 - Item no contiene definición para Estudio

Para ayudarte mejor necesito ver el contenido de estos archivos:

Program.cs - tiene la mayoría de errores (líneas 9, 13, 15)
Agregar.cshtml - error en línea 17 con Estudio
CatalogoController.cs - para entender el modelo
items.json - para ver la estructura de datos

¿Puedes pegarme el código de esos archivos? Especialmente Program.cs y Agregar.cshtml que parecen ser los más problemáticos. Puedes copiar y pegar el texto directamente aquí.

---
