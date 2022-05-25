using System;

namespace Curso_De_ASP_NET_Core
{
    public class Evaluación: ObjetoEscuelaBase
    {

        public string AlumnoId { get; set; }
        public Alumno Alumno { get; set; }

        public string AsignaturaId { get; set; }
        public Asignatura Asignatura  { get; set; }

        public float Nota { get; set; }

        public override string ToString()
        {
            return $"{Nota},{Alumno.Nombre},{Asignatura}";
        }

    }
}