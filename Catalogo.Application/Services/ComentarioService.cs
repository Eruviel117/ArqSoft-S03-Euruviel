using System;
using System.Collections.Generic;
using System.Text;

using System.Text.Json;
using CatalogoApp.Domain.Models;

namespace CatalogoApp.Application.Services
{
    public class ComentarioService
    {
        private readonly string _path;

        public ComentarioService(string path)
        {
            _path = path;
            var carpeta = Path.GetDirectoryName(_path);
            if (!string.IsNullOrEmpty(carpeta))
                Directory.CreateDirectory(carpeta);
            if (!File.Exists(_path))
                File.WriteAllText(_path, "[]");
        }

        private List<Comentario> Leer()
        {
            var json = File.ReadAllText(_path);
            return JsonSerializer.Deserialize<List<Comentario>>(json) ?? new();
        }

        private void Guardar(List<Comentario> lista)
        {
            var json = JsonSerializer.Serialize(lista,
                new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_path, json);
        }

        public List<Comentario> ObtenerPorItem(int itemId)
        {
            return Leer().Where(c => c.ItemId == itemId)
                         .OrderByDescending(c => c.Fecha)
                         .ToList();
        }

        public void Agregar(Comentario comentario)
        {
            var lista = Leer();
            comentario.Id = lista.Count > 0 ? lista.Max(c => c.Id) + 1 : 1;
            comentario.Fecha = DateTime.Now;
            lista.Add(comentario);
            Guardar(lista);
        }
    }
}