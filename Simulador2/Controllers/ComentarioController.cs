using Simulador2.BD;
using Simulador2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Simulador2.Controllers
{
    public class ComentarioController : Controller
    {
        public StoreContext context = new StoreContext();

        public ActionResult Index(int LibroId)
        {
            ViewBag.IdLibro = LibroId;
            // ViewBag.Comentarios = context.Comentarios.ToList();
            //var comentarios = context.Comentarios.Where(a=> a.LibroId == IdLibro).FirstOrDefault();
            // var comentarios = context.Comentarios.Find(IdLibro);
            var comentarios = context.Libros.Include(a => a.Comentarios).Where(a => a.Id == LibroId).ToList();
            return View(comentarios);
        }

        [HttpGet]
        public ActionResult Comentar(int idLibro, int idUsuario)
        {
            ViewBag.usuario = idUsuario;
            ViewBag.libro = idLibro;


            return View(new Coment());
        }
        [HttpPost]
        public ActionResult Comentar(Coment comentario, int idLibro/*, int idUsuario*/)
        {
            //ViewBag.usuario = idUsuario;
            ViewBag.libro = idLibro;

            if (ModelState.IsValid)
            {
                comentario.LibroId = idLibro;
                //comentario.UsuarioId = idUsuario;

                ViewBag.captura = "Comentario Agregado";
                context.Comentarios.Add(comentario);
                context.SaveChanges();
            }

            return View();
        }
    }
}
       
