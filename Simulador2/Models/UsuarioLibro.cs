using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Simulador2.Models
{
    public class UsuarioLibro
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int LibroId { get; set; }

        public Libro Libro { get; set; }
        public Usuario Usuario{ get; set; }
    }
}