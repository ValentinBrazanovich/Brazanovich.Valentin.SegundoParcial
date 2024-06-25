using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roedores
{
    public class Terrario : IPesoPromedio, IOperaciones
    {
        private List<Roedor> roedores;

        /// <summary>
        /// En el metodo constructor se declara la lista roedores que contendra instancias
        /// de las clases derivadas de Roedor.
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
        /// Agrega un roedor a la lista de roedores
        /// </summary>
        /// <param name="roedor"> El roedor que se agrega </param>
        void IOperaciones.AgregarRoedor(Roedor roedor) 
        {
            roedores.Add(roedor);
        }

        /// <summary>
        /// Elimina un roedor de la lista de roedores
        /// </summary>
        /// <param name="roedor"> El roedor que se eliminará </param>
        void IOperaciones.EliminarRoedor(Roedor roedor)
        {
            roedores.Remove(roedor);
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
                Gestion.AgregarRoedorAlTerrario(t, r);
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
            if(t == r)
            {
                Gestion.EliminarRoedorDelTerrario(t, r);
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

        /// <summary>
        /// Se ordena la lista por nombres de manera ascendente o descendente
        /// (según indique el parametro)
        /// </summary>
        /// <param name="ascendente"> Indica si se ordenara de forma ascendente o descendente</param>
        public void OrdenarPorNombre(bool ascendente)
        {
            if (ascendente)
            {
                roedores = roedores.OrderBy(r => r.Nombre).ToList();
            }
            else
            {
                roedores = roedores.OrderByDescending(r => r.Nombre).ToList();
            }
        }


        /// <summary>
        /// Se ordena la lista por peso de manera ascendente o descendente
        /// (según indique el parametro)
        /// </summary>
        /// <param name="ascendente"> Indica si se ordenara de forma ascendente o descendente</param>
        public void OrdenarPorPeso(bool ascendente)
        {
            if (ascendente)
            {
                roedores = roedores.OrderBy(r => r.Peso).ToList();
            }
            else
            {
                roedores = roedores.OrderByDescending(r => r.Peso).ToList();
            }
        }

        /// <summary>
        /// Calcula el peso promedio del tipo de roedor especificado
        /// como parámetro
        /// </summary>
        /// <typeparam name="T"> El tipo de roedor </typeparam>
        /// <returns> Retorna el promedio calculado o 0 si no hay un
        /// roedor del tipo especificado </returns>
        double IPesoPromedio.CalcularPesoPromedio<T>()
        {
            var roedoresDelTipo = roedores.OfType<T>();

            if (roedoresDelTipo.Any())
            {
                return roedoresDelTipo.Average(r => r.Peso);
            }

            return 0;
        }

    }
}
