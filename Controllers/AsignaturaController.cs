using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curso_De_ASP_NET_Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Curso_De_ASP_NET_Core.Controllers
{
    public class AsignaturaController : Controller
    {
        /*public IActionResult Index()
        {
            return View( _context.Asignaturas.FirstOrDefault());
        }*/
        [Route("Asignatura/Index")]
        [Route("Asignatura/Index/{asignaturaId}")]
        public IActionResult Index(string asignaturaId)
        {
            if (!string.IsNullOrWhiteSpace(asignaturaId))
            {
                var asignatura = from asig in _context.Asignaturas
                                 where asig.Id == asignaturaId
                                 select asig;
                return View(asignatura.SingleOrDefault());
            }
            else
            {
                return View("MultiAsignatura", _context.Asignaturas);
            }

        }
        public IActionResult MultiAsignatura()
        {
            ViewBag.CosaDinamica = "La Monja";
            ViewBag.Fecha = DateTime.Now;

            return View("MultiAsignatura", _context.Asignaturas);
        }

        #region Crear Asignatura
        public IActionResult Create()
        {
            ViewBag.Fecha = DateTime.Now;

            return View();
        }


        [HttpPost]
        public IActionResult Create(Asignatura asignatura)
        {
            ViewBag.Fecha = DateTime.Now;

            if (ModelState.IsValid)
            {

                var escuela = _context.Escuelas.FirstOrDefault();
                asignatura.EscuelaId = escuela.Id;
                _context.Asignaturas.Add(asignatura);
                _context.SaveChanges();
                ViewBag.MensajeExra = "Asignatura Creada";
                return View("Index", asignatura);
            }
            else
            {
                return View(asignatura);
            }
        }
        #endregion

        #region Actualizar Asignatura
        public IActionResult Update()
        {
            ViewBag.Fecha = DateTime.Now;

            return View();
        }


        [HttpPost]
        [Route("Asignatura/Update")]
        [Route("Asignatura/Update/{asignaturaId}")]
        public IActionResult Update(Asignatura asignatura)
        {
            ViewBag.Fecha = DateTime.Now;

            if (ModelState.IsValid)
            {

                var escuela = _context.Escuelas.FirstOrDefault();
                asignatura.EscuelaId = escuela.Id;
                _context.Asignaturas.Update(asignatura);
                _context.SaveChanges();
                ViewBag.MensajeExra = "Asignatura Actualizada";
                return View("Update", asignatura);
            }
            else
            {
                return View(asignatura);
            }
        }
        #endregion

        private EscuelaContext _context;
        public AsignaturaController(EscuelaContext context)
        {
            _context = context;
        }
    }
}