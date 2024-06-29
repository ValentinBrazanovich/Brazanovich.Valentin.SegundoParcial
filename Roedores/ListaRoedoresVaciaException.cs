using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ListaRoedoresVaciaException : Exception
    {
        public ListaRoedoresVaciaException() : base("Primero debe ingresar al menos un roedor.")
        {
        }

    }
}
