using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Simulador2.Models
{
    public class Coment
    {
        public int Id { get; set; }

        public int LibroId { get; set; }
      
        public string Nombre { get; set; }

        public Libro Libro { get; set; }
       
    }
}