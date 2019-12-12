using Simulador2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Simulador2.BD.Maps
{
    public class LibroMap:EntityTypeConfiguration<Libro>
    {
        public LibroMap()
        {
            ToTable("Libro");
            HasKey(a=>a.Id);

            HasRequired(a=>a.Categoria).WithMany().HasForeignKey(a=>a.CategoriaId);
        }
    }
}