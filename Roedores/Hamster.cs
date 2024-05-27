using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roedores
{
    public class Hamster : Roedor
    {
        public double longitud;
        public bool esNocturno;


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


        public override string obtenerSonido()
        {
            return "Hiss!";
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString()).Append(" - ");
            sb.Append($"Longitud: {this.longitud}cm - ");
            sb.Append($"Nocturno: {this.esNocturno}");

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

        public override int GetHashCode()
        {
            return (base.GetHashCode(), longitud, esNocturno).GetHashCode();
        }


        public override string PesoIdeal()
        {
            string rta;
            if (((this.peso >= 0.045 && this.peso <= 0.065) && (this.longitud >= 6.0 && this.longitud <= 10.0)) ||
               ((this.peso >= 0.085 && this.peso <= 0.150) && (this.longitud >= 10.0 && this.longitud <= 18.0)))
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
