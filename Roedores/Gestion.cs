using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roedores
{
    public static class Gestion
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"> El tipo de roedor </typeparam>
        /// <param name="t"> El terrario con los roedores </param>
        /// <returns></returns>
        public static double MostrarPromedioRoedor<T>(IPesoPromedio t) where T : Roedor
        {
            return t.CalcularPesoPromedio<T>();
        }

        public static void AgregarRoedorAlTerrario(IOperaciones t, Roedor roedor)
        {
            t.AgregarRoedor(roedor);
        }

        public static void EliminarRoedorDelTerrario(IOperaciones t, Roedor roedor)
        {
            t.EliminarRoedor(roedor);
        }
    }
}
