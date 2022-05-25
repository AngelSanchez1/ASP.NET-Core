//Esta es la clases padre del cual se aplicara la herencia a las demas clases
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso_De_ASP_NET_Core
{
    // Una clase abstracta (asbtract) puede ser heredada pero no instanciada
    public abstract class ObjetoEscuelaBase
    {
        public string Id { get;  set; } // propiedad que asigna un unico Id a las clases
        public virtual string Nombre { get; set; } // propiedad que se usa para asignar el nombre a la clase que lo herede

        //constructor que es es encargado que el objeto con unico Id lo convierta en variable string
        public ObjetoEscuelaBase()
        {
            
        }

        public override string ToString()
        {
            return $"{Nombre},{Id}";
        }
    }
}