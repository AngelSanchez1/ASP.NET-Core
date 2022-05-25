using System.Linq;
using System;
using Curso_De_ASP_NET_Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Curso_De_ASP_NET_Core.Controllers
{
    public class EscuelaController : Controller
    {
        public IActionResult  Index()
        {
            /*var escuela = new Escuela();
            escuela.AñoDeCreación=2013;
            escuela.UniqueId = Guid.NewGuid().ToString();
            escuela.Nombre="Pixeles Eschool";
            escuela.Ciudad="Merida";
            escuela.Pais="México";
            escuela.Dirección="Calle 31 x 14 y 12";
            escuela.TipoEscuela=TiposEscuela.Secundaria;*/

            var escuela = _context.Escuelas.FirstOrDefault();
            

            ViewBag.CosaDinamica = "La monja";

            return View(escuela);
        }

        
        private EscuelaContext _context;
        public EscuelaController(EscuelaContext context)
        {
            _context = context;
        }
    }
}