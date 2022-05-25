using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curso_De_ASP_NET_Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Curso_De_ASP_NET_Core.Controllers
{
    public class CursoController : Controller
    {
        [Route("Curso/Index")]
        [Route("Curso/Index/{CursoId}")]
        public IActionResult Index(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                var curso = from cur in _context.Cursos
                            where cur.Id == id
                            select cur;
                return View(curso.SingleOrDefault());
            }
            else
            {
                return View("MultiCurso", _context.Cursos);
            }

        }
        public IActionResult MultiCurso()
        {
            ViewBag.CosaDinamica = "La monja";
            ViewBag.Fecha = DateTime.Now;
            return View("MultiCurso", _context.Cursos);
        }
        #region Crear Curso
        public IActionResult Create()
        {
            ViewBag.Fecha = DateTime.Now;

            return View();
        }


        [HttpPost]
        public IActionResult Create(Curso curso)
        {
            ViewBag.Fecha = DateTime.Now;

            if (ModelState.IsValid)
            {

                var escuela = _context.Escuelas.FirstOrDefault();
                curso.EscuelaId = escuela.Id;
                _context.Cursos.Add(curso);
                _context.SaveChanges();
                ViewBag.MensajeExra = "Curso Creado";
                return View("Index", curso);
            }
            else
            {
                return View(curso);
            }
        }
        #endregion

        #region Actualizar Curso
        public IActionResult Update()
        {
            ViewBag.Fecha = DateTime.Now;

            return View();
        }


        [HttpPost]
        [Route("Curso/Update")]
        [Route("Curso/Update/{cursoId}")]
        public IActionResult Update(Curso curso)
        {
            ViewBag.Fecha = DateTime.Now;

            if (ModelState.IsValid)
            {

                var escuela = _context.Escuelas.FirstOrDefault();
                curso.EscuelaId = escuela.Id;
                _context.Cursos.Update(curso);
                _context.SaveChanges();
                ViewBag.MensajeExra = "curso Actualizada";
                return View("Update", curso);
            }
            else
            {
                return View(curso);
            }
        }
        #endregion

        #region Actualizar Curso
        public IActionResult Delete()
        {
            ViewBag.Fecha = DateTime.Now;

            return View();
        }


        [HttpPost]
        [Route("Curso/Delete")]
        [Route("Curso/Delete/{cursoId}")]
        public IActionResult Delete(Curso curso)
        {
            ViewBag.Fecha = DateTime.Now;

            if (ModelState.IsValid)
            {

                var escuela = _context.Escuelas.FirstOrDefault();
                curso.EscuelaId = escuela.Id;
                _context.Cursos.Remove(curso);
                _context.SaveChanges();
                ViewBag.MensajeExra = "curso Borrado";
                return View("Delete", curso);
            }
            else
            {
                return View(curso);
            }
        }
        #endregion
        private EscuelaContext _context;
        public CursoController(EscuelaContext context)
        {
            _context = context;
        }

    }
}