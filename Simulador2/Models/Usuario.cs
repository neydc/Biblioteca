using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Simulador2.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public List<UsuarioLibro> libros { get; set; }

        //public List<Coment> libroscomentarios{ get; set; }

    }
}