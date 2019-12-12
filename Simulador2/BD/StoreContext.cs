using Simulador2.BD.Maps;
using Simulador2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Simulador2.BD
{
    public class StoreContext : DbContext
    {
        public IDbSet<Categoria> Categorias { get; set; }
        public IDbSet<Usuario> Usuarios { get; set; }
        public IDbSet<Libro> Libros { get; set; }
        public IDbSet<Coment> Comentarios{ get; set; }
        public IDbSet<UsuarioLibro> Capturas{ get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new LibroMap());
            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new CategoriaMap());
            modelBuilder.Configurations.Add(new UsuarioLibroMap());
            modelBuilder.Configurations.Add(new ComentMap()); 
        }
    }
}