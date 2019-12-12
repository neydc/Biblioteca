using Simulador2.BD;
using Simulador2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Simulador2.Controllers
{
    public class LibroController : Controller
    {
        public StoreContext context = new StoreContext();
        public ActionResult Index(int? id)
        {
            ViewBag.usuario = id;
            return View(context.Libros.ToList());
        }

        public ActionResult IndexBuscar(string nom, int? id)
        {
        
            ViewBag.usuario = id;
            var buscando = context.Libros.Where(o => o.Titulo == nom).FirstOrDefault();
            return PartialView(buscando);
        }

        public ActionResult Crear()
        {
            
            return View(new Libro());
        }
        [HttpPost]
        public ActionResult Crear(Libro libro, HttpPostedFileBase file)
        {

            if (file != null && file.ContentLength > 0)
            {
                string ruta = Path.Combine(Server.MapPath("~/imagenes"), Path.GetFileName(file.FileName));
                file.SaveAs(ruta);
                libro.Imagen = "/imagenes/" + Path.GetFileName(file.FileName);
            }

            if (ModelState.IsValid)
            {
               // libro.CategoriaId = 5;
                
                context.Libros.Add(libro);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(libro);
        }
        public ActionResult Detalle(int IdLibro)
        {
            ViewBag.LibroId = IdLibro;
            Libro libro = context.Libros.Find(IdLibro);
            return View(libro);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View(new Usuario());

        }
        [HttpPost]
        public ActionResult Login(Usuario user)
        {
            var aux = new Usuario();
            aux = context.Usuarios.Where(o => o.Username == user.Username).FirstOrDefault();
            if (aux == null)
            {
                ModelState.AddModelError("Username", "ES INVALIDO");
            }
            else
            {
                if (aux.Password != user.Password)
                {
                    ModelState.AddModelError("Password", "ES INVALIDO");
                }
            }
            if (ModelState.IsValid)
            {
                FormsAuthentication.SetAuthCookie(aux.Username, false);
                System.Web.HttpContext.Current.Session["Usuario"] = aux;
                return RedirectToAction("Index", new { id = aux.Id });
            }

            return View(user);

        }
        public ActionResult Salir()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");

        }
        public ActionResult Agregar(int idLibro, int idUsuario)
        {
            ViewBag.usuario = idUsuario;
            if (ModelState.IsValid)
            {
                var cap = new UsuarioLibro();
                cap.LibroId = idLibro;
                cap.UsuarioId = idUsuario;
                ViewBag.captura = "Libro Agregado Correctamente";
                context.Capturas.Add(cap);
                context.SaveChanges();
            }
            
            return View();
        }

      
        
        public ActionResult MisLibros(int id)
        {
            ViewBag.usuario = id;
            var miscap = context.Capturas.Where(o => o.UsuarioId == id).ToList();
            List<Libro> misLibros = new List<Libro>();
            foreach (var aux in miscap)
            {
                var ex = context.Libros.Where(o => o.Id == aux.LibroId).FirstOrDefault();
                if (ex != null)
                {
                    misLibros.Add(ex);
                }
            }
            return View(misLibros);
        }
    }
}