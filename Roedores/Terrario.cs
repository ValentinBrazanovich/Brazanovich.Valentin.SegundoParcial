using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roedores
{
    public class Terrario
    {
        private List<Roedor> roedores;

        /// <summary>
        /// En el metodo constructor se declara la lista roedores que contendra instancias
        /// de la clase Roedor y/o sus clases derivadas
        /// </summary>
        public Terrario()
        {
            roedores = new List<Roedor>();
        }

        public List<Roedor> Roedores
        {
            get { return roedores; }
            set { roedores = value; }
        }

        /// <summary>
        /// Si la instancia de la clase Roedor no existe en la lista de roedores del terrario,
        /// entonces se agrega a la misma, caso contrario no se agrega.
        /// </summary>
        /// <param name="t"> El terrario (lista) </param>
        /// <param name="r"> El roedor que se quiere integrar </param>
        /// <returns> Segun el caso, se devuelve la lista con o sin el roedor
        /// que se pretende integrar</returns>
        public static Terrario operator +(Terrario t, Roedor r)
        {
            if (t != r)
            {
                t.roedores.Add(r);
            }
            return t;
        }


        /// <summary>
        /// Si la instancia de la clase Roedor existe en la lista de roedores del terrario,
        /// entonces se elimina de la misma, caso contrario no se hace nada.
        /// </summary>
        /// <param name="t"> El terrario (lista) </param>
        /// <param name="r"> El roedor que se quiere eliminar </param>
        /// <returns> Segun el caso, se devuelve la lista con un roedor menos </returns>
        public static Terrario operator -(Terrario t, Roedor r)
        {
            if (t == r)
            {
                t.roedores.Remove(r);
            }
            return t;
        }

        /// <summary>
        /// Se sobrecarga el operador == para que verifique si se tiene el roedor ingresado
        /// por parametro en el terrario (lista).
        /// </summary>
        /// <param name="t"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool operator ==(Terrario t, Roedor r)
        {
            return t.roedores.Contains(r);
        }

        public static bool operator !=(Terrario t, Roedor r)
        {
            return !(t == r);
        }

        public override bool Equals(object? obj)
        {
            if (obj is Terrario)
            {
                return ((Terrario)obj) == this;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return roedores.GetHashCode();
        }


        public void OrdenarPorNombre(bool ascendente)
        {
            if (ascendente)
            {
                roedores = roedores.OrderBy(r => r.nombre).ToList();
            }
            else
            {
                roedores = roedores.OrderByDescending(r => r.nombre).ToList();
            }
        }

        public void OrdenarPorPeso(bool ascendente)
        {
            if (ascendente)
            {
                roedores = roedores.OrderBy(r => r.peso).ToList();
            }
            else
            {
                roedores = roedores.OrderByDescending(r => r.peso).ToList();
            }
        }


    }
}
