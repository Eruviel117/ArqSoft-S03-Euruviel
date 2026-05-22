using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using CatalogoApp.Domain.Interfaces;
using CatalogoApp.Domain.Models;

namespace CatalogoApp.Infrastructure.Repositories
{
    public class JsonItemRepository : IItemRepository
    {
        private readonly string _filePath;

        public JsonItemRepository(string filePath)
        {
            _filePath = filePath;
            var carpeta = Path.GetDirectoryName(_filePath);
            if (!string.IsNullOrEmpty(carpeta))
                Directory.CreateDirectory(carpeta);
        }

        public List<Item> ObtenerTodos()
        {
            if (!File.Exists(_filePath))
                return new List<Item>();
            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Item>>(json) ?? new List<Item>();
        }

        public Item? ObtenerPorId(int id)
        {
            return ObtenerTodos().FirstOrDefault(i => i.Id == id);
        }

        public void Agregar(Item item)
        {
            var items = ObtenerTodos();
            item.Id = items.Count > 0 ? items.Max(i => i.Id) + 1 : 1;
            items.Add(item);
            Guardar(items);
        }

        public void Eliminar(int id)
        {
            var items = ObtenerTodos();
            var aEliminar = items.FirstOrDefault(i => i.Id == id);
            if (aEliminar != null)
            {
                items.Remove(aEliminar);
                Guardar(items);
            }
        }

        // ← ESTE es el único Guardar, público para que el servicio lo llame
        public void Guardar(List<Item> items)
        {
            var opciones = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(items, opciones);
            File.WriteAllText(_filePath, json);
        }
    }
}