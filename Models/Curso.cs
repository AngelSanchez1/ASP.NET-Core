using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//using Curso_De_ASP_NET_Core-DE-ASP-NET-CORE.util;

namespace Curso_De_ASP_NET_Core
{
    public class Curso: ObjetoEscuelaBase
    {   
        [Display(Prompt ="Nombre del curso", Name ="Nombre")]
        [Required(ErrorMessage ="El nombre del curso es requerido")]
        //[StringLength(5, ErrorMessage = "La longitud maxima es de 5 caracteres")]
        [StringLength(5)]
        public override string Nombre { get; set; }

        [Display(Prompt ="Jornada", Name ="Jornada")]
        public TiposJornada Jornada { get; set; }
        public List<Asignatura> Asignaturas{ get; set; }
        public List<Alumno> Alumnos{ get; set; }

        [Display(Prompt ="Dirección de correspondencia", Name ="Dirección")]
        [Required(ErrorMessage ="Se requiere incluir una dirección")]
        [MinLength(10, ErrorMessage="El minimo de caracteres es 10")]
        public string Dirección { get ; set; }

        public string EscuelaId { get; set; }
        public Escuela Escuela{ get; set; }
    }
}