using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roedores
{
    public class Hamster : Roedor
    {
        public string raza;
        public bool esNocturno;


        public Hamster(string nombre, double peso, string raza, bool esNocturno)
            : base(nombre, peso, ETipoAlimentacion.Omnivoro)
        {
            this.raza = raza;
            this.esNocturno = esNocturno;
        }

        public Hamster(string nombre, string raza, bool esNocturno)
            : base(nombre, ETipoAlimentacion.Omnivoro)
        {
            this.raza = raza;
            this.esNocturno = esNocturno;
        }

        public Hamster(string nombre, string raza)
            : base(nombre)
        {
            this.raza = raza;
            this.esNocturno = true;
        }


        public override string obtenerSonido()
        {
            return "Hiss!";
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString()).Append(" - ");
            sb.Append($"Raza: {this.raza}.raza - ");
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
            return (base.GetHashCode(), raza, esNocturno).GetHashCode();
        }


        public override string PesoIdeal()
        {
            string rta;
            if (((this.peso >= 0.045 && this.peso <= 0.065) && (this.raza == "ruso")) ||
               ((this.peso >= 0.085 && this.peso <= 0.150) && (this.raza == "sirio")))
            {
                rta = " ";

            }
            else
            {
                rta = " no ";
            }

            return $"El hámster {this.raza}{rta}está en su peso ideal (45g - 65g ruso, 85g - 150g sirio)";
        }
    }
}
