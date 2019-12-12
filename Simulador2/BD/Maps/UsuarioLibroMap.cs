using Simulador2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Simulador2.BD.Maps
{
    public class UsuarioLibroMap:EntityTypeConfiguration<UsuarioLibro>
    {
        public UsuarioLibroMap()
        {
            ToTable("UsuarioLibro");
            HasKey(a=>a.Id);

            HasRequired(a => a.Libro).WithMany(a => a.usuarios)
                .HasForeignKey(a => a.LibroId);

            HasRequired(a => a.Usuario).WithMany(a => a.libros).HasForeignKey(a => a.UsuarioId);
        }
    }
}