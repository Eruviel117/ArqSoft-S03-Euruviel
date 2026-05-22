using System.Text.Json;
using CatalogoApp.Domain.Models;

namespace CatalogoApp.Application.Services
{
    public class UsuarioService
    {
        private readonly string _path;

        public UsuarioService(string path)
        {
            _path = path;
            var carpeta = Path.GetDirectoryName(_path);
            if (!string.IsNullOrEmpty(carpeta))
                Directory.CreateDirectory(carpeta);
            if (!File.Exists(_path))
                File.WriteAllText(_path, "[]");
        }

        private List<Usuario> Leer()
        {
            var json = File.ReadAllText(_path);
            return JsonSerializer.Deserialize<List<Usuario>>(json) ?? new();
        }

        private void Guardar(List<Usuario> usuarios)
        {
            var json = JsonSerializer.Serialize(usuarios,
                new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_path, json);
        }

        public bool Registrar(string nombreUsuario, string password)
        {
            var usuarios = Leer();
            if (usuarios.Any(u => u.NombreUsuario == nombreUsuario))
                return false; // ya existe

            var nuevo = new Usuario
            {
                Id = usuarios.Count > 0 ? usuarios.Max(u => u.Id) + 1 : 1,
                NombreUsuario = nombreUsuario,
                Password = password
            };
            usuarios.Add(nuevo);
            Guardar(usuarios);
            return true;
        }

        public Usuario? Login(string nombreUsuario, string password)
        {
            return Leer().FirstOrDefault(u =>
                u.NombreUsuario == nombreUsuario && u.Password == password);
        }
    }
}