using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roedores
{
    public class Raton : Roedor
    {
        private double largoCola;
        private bool esAlbino;

        public static string TypeDiscriminator => "Raton";

        public Raton(string nombre, double peso, ETipoAlimentacion tipoAlimentacion, double largoCola, bool esAlbino)
            : base(nombre, peso, tipoAlimentacion)
        {
            this.largoCola = largoCola;
            this.esAlbino = esAlbino;
        }

        public Raton(string nombre, ETipoAlimentacion tipoAlimentacion, double largoCola, bool esAlbino)
            : base(nombre, tipoAlimentacion)
        {
            this.largoCola = largoCola;
            this.esAlbino = esAlbino;
        }

        public Raton(string nombre, bool esAlbino)
            : base(nombre)
        {
            this.largoCola = 8.0;
            this.esAlbino = esAlbino;
        }

        public Raton() {
            this.largoCola = 0;
            this.esAlbino = false;
        }

        public double LargoCola
        {
            get { return largoCola; }
            set { largoCola = value;}
        }

        public bool EsAlbino
        {
            get { return esAlbino; }
            set { esAlbino = value; }
        }

        public override string ObtenerSonido()
        {
            return "Squeak";
        }

        public override string MoverCola()
        {
            return "El ratón mueve su larga cola";
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString()).Append(" - ");
            sb.Append($"Largo de cola: {this.LargoCola}cm - ");
            sb.Append($"Albino: {this.EsAlbino}");
            sb.Append($" /// Es: Ratón");

            return sb.ToString();
        }

        public override bool Equals(object? obj)
        {
            if (base.Equals(obj))
            {
                return ((Raton)obj) == this;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return (base.GetHashCode(), LargoCola, EsAlbino).GetHashCode();
        }


        public override string PesoIdeal()
        {
            string rta;
            if (this.Peso >= 25 && this.Peso <= 50)
            {
                rta = " ";
            }
            else
            {
                rta = " no ";
            }

            return $"El ratón{rta}está en su peso ideal (25g - 50g)";
        }
    }
}
