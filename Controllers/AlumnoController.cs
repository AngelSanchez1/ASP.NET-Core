using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curso_De_ASP_NET_Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Curso_De_ASP_NET_Core.Controllers
{
    public class AlumnoController : Controller
    {
        [Route("Alumno/Index")]
        [Route("Alumno/Index/{AlumnoId}")]
        public IActionResult Index(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                var alumno = from alum in _context.Alumnos
                                 where alum.Id == id
                                 select alum;
                return View(alumno.SingleOrDefault());
            }
            else
            {
                return View("MultiAlumno", _context.Alumnos);
            }

        }
        public IActionResult MultiAlumno()
        {
            ViewBag.CosaDinamica = "La monja";
            ViewBag.Fecha = DateTime.Now;
            return View("MultiAlumno", _context.Alumnos);
        }
        
         #region Crear Alumnos
        public IActionResult Create()
        {
            ViewBag.Fecha = DateTime.Now;

            return View();
        }


        [HttpPost]
        public IActionResult Create(Alumno alumno)
        {
            ViewBag.Fecha = DateTime.Now;

            if (ModelState.IsValid)
            {

                var escuela = _context.Escuelas.FirstOrDefault();
                alumno.EscuelaId = escuela.Id;
                _context.Alumnos.Add(alumno);
                _context.SaveChanges();
                ViewBag.MensajeExra = "Curso Creado";
                return View("Index", alumno);
            }
            else
            {
                return View(alumno);
            }
        }
        #endregion

        #region Actualizar Alumno
        public IActionResult Update()
        {
            ViewBag.Fecha = DateTime.Now;

            return View();
        }


        [HttpPost]
        [Route("Alumno/Update")]
        [Route("Alumno/Update/{alumnoId}")]
        public IActionResult Update(Alumno alumno)
        {
            ViewBag.Fecha = DateTime.Now;

            if (ModelState.IsValid)
            {

                var escuela = _context.Escuelas.FirstOrDefault();
                alumno.EscuelaId = escuela.Id;
                _context.Alumnos.Update(alumno);
                _context.SaveChanges();
                ViewBag.MensajeExra = "alumno Actualizada";
                return View("Update", alumno);
            }
            else
            {
                return View(alumno);
            }
        }
        #endregion
        private EscuelaContext _context;
        public AlumnoController(EscuelaContext context)
        {
            _context = context;
        }

    }
}