using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Simulador2.Models
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Resumen { get; set; }
        public string Imagen { get; set; }
        public string Estado { get; set; }
        //public int CategoriaId { get; set; }

        public List<UsuarioLibro> usuarios { get; set; }

        public List<Coment> Comentarios { get; set; }
        // public Categoria Categoria{ get; set; }

        public Libro()
        {
            Comentarios = new List<Coment>();
        }
       
    }
}