using Simulador2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Simulador2.BD.Maps
{
    public class ComentMap:EntityTypeConfiguration<Coment>
    {
        public ComentMap()
        {
            ToTable("Coment");
            HasKey(a => a.Id);

            HasRequired(a => a.Libro).WithMany(a => a.Comentarios).HasForeignKey(a => a.LibroId);
            }
    }
}