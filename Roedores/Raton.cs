using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roedores
{
    public class Raton : Roedor
    {
        public double largoCola;
        public bool esAlbino;


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


        public override string obtenerSonido()
        {
            return "Squeak";
        }

        public override string moverCola()
        {
            return "El ratón mueve su larga cola";
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString()).Append(" - ");
            sb.Append($"Largo de cola: {this.largoCola} - ");
            sb.Append($"Albino: {this.esAlbino}");

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
            return (base.GetHashCode(), largoCola, esAlbino).GetHashCode();
        }


        public override string PesoIdeal()
        {
            string rta;
            if (this.peso >= 0.025 && this.peso <= 0.050)
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
