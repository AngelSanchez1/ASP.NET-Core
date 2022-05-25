using System;
using System.Collections.Generic;

namespace Curso_De_ASP_NET_Core
{
    public class Alumno : ObjetoEscuelaBase
    {
        public string CursoId { get; set; }
        public Curso Curso { get; set; }
        public List<Evaluación> Evaluaciones { get; set; }
        public string EscuelaId { get; set; }
        public Escuela Escuela { get; set; }

    }

}