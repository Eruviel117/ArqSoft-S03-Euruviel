using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogoApp.Domain.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public string Estudio { get; set; } = string.Empty;  // ← AGREGAR ESTO
        public int Ano { get; set; }
        public string Estado { get; set; } = string.Empty;
        public int Calificacion { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public string ImagenUrl { get; set; } = string.Empty;
    }
}
