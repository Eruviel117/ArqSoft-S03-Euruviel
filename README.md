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
