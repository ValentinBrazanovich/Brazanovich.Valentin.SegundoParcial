using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Hamster : Roedor
    {
        private double longitud;
        private bool esNocturno;

        public static string TypeDiscriminator => "Hamster";

        public Hamster(string nombre, double peso, ETipoAlimentacion tipoAlimentacion, double longitud, bool esNocturno)
            : base(nombre, peso, tipoAlimentacion)
        {
            this.longitud = longitud;
            this.esNocturno = esNocturno;
        }

        public Hamster(string nombre, ETipoAlimentacion tipoAlimentacion, double longitud, bool esNocturno)
            : base(nombre, tipoAlimentacion)
        {
            this.longitud = longitud;
            this.esNocturno = esNocturno;
        }

        public Hamster(string nombre, bool esNocturno)
            : base(nombre)
        {
            this.longitud = 8;
            this.esNocturno = esNocturno;
        }

        public Hamster() {
            this.longitud = 4;
            this.esNocturno = false;
        }

        public double Longitud
        {
            get { return longitud; }
            set { longitud = value; }
        }

        public bool EsNocturno
        {
            get { return esNocturno; }
            set { esNocturno = value;}
        }

        public override string ObtenerSonido()
        {
            return "Hiss!";
        }

        /// <summary>
        /// Sobrecarga del método ToString para la clase actual. Se implementa StringBuilder y
        /// el método sobrecargado de la clase padre.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString()).Append(" - ");
            sb.Append($"Longitud: {this.Longitud}cm - ");
            sb.Append($"Nocturno: {this.EsNocturno}");
            sb.Append($" /// Es: Hámster");

            return sb.ToString();
        }

        public override bool Equals(object? obj)
        {
            if (base.Equals(obj))
            {
                return ((Hamster)obj) == this;
            }
            else
            {
                return false;
            }
        }

        public static bool operator ==(Hamster h1, Hamster h2)
        {
            if (ReferenceEquals(h1, h2))
            {
                return true;
            }
            if (h1 is null || h2 is null)
            {
                return false;
            }

            return h1.Nombre == h2.Nombre &&
                   h1.Peso == h2.Peso &&
                   h1.TipoAlimentacion == h2.TipoAlimentacion &&
                   h1.longitud == h2.longitud &&
                   h1.esNocturno == h2.esNocturno;
        }

        public static bool operator !=(Hamster h1, Hamster h2)
        {
            return !(h1 == h2);
        }

        public override int GetHashCode()
        {
            return (base.GetHashCode(), Longitud, EsNocturno).GetHashCode();
        }

        /// <summary>
        /// Determina si el peso del Hámster es el ideal o no dependiendo de su peso y longitud.
        /// </summary>
        /// <returns>La cadena que dice si el Hámster está en su peso ideal y un estimativo</returns>
        public override string PesoIdeal()
        {
            string rta;
            if (((this.Peso >= 45 && this.Peso <= 65) && (this.Longitud >= 6.0 && this.Longitud <= 10.0)) ||
               ((this.Peso >= 85 && this.Peso <= 150) && (this.Longitud >= 10.0 && this.Longitud <= 18.0)))
            {
                rta = " ";

            }
            else
            {
                rta = " no ";
            }

            return $"El hámster{rta}está en su peso ideal\n\t(45g - 65g ruso, 85g - 150g sirio)";
        }

    }
}
