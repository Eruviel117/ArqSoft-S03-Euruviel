using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogoApp.Domain.Models
{
    public class Comentario
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string Usuario { get; set; } = string.Empty;
        public string Texto { get; set; } = string.Empty;
        public int Calificacion { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}
