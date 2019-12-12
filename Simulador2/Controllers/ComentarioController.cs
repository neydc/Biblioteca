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

        public ActionResult Index(int idLibro)
        {
            
            ViewBag.LibroId = idLibro;

            var comentario = context.Comentarios.Where(a=>a.LibroId==idLibro).FirstOrDefault();
            return View(comentario); 
        }
    }
       
}