using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso_De_ASP_NET_Core
{
    public interface ILugar
    {
        string Dirección { get; set; }

        void LimpiarLugar();   
    }
}