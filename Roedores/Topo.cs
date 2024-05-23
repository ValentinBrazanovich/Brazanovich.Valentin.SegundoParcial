using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roedores
{
    public class Topo : Roedor
    {
        public double profundidadExcavada;
        public bool garrasAfiladas;


        public double largoCola;
        public bool esAlbino;


        public Topo(string nombre, double peso, double profundidadExcavada, bool garrasAfiladas)
            : base(nombre, peso, ETipoAlimentacion.Insectivoro)
        {
            this.profundidadExcavada = profundidadExcavada;
            this.garrasAfiladas = garrasAfiladas;
        }

        public Topo(string nombre, double profundidadExcavada, bool garrasAfiladas)
            : base(nombre, ETipoAlimentacion.Insectivoro)
        {
            this.profundidadExcavada = profundidadExcavada;
            this.garrasAfiladas = garrasAfiladas;
        }

        public Topo(string nombre, double profundidadExcavada)
            : base(nombre, ETipoAlimentacion.Insectivoro)
        {
            this.profundidadExcavada = profundidadExcavada;
            this.garrasAfiladas = true;
        }


        public override string obtenerSonido()
        {
            return "Gruñido";
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString()).Append(" - ");
            sb.Append($"Profundidad excavada: {this.profundidadExcavada} - ");
            sb.Append($"Garras afiladas: {this.garrasAfiladas}");

            return sb.ToString();
        }

        public override bool Equals(object? obj)
        {
            if (base.Equals(obj))
            {
                return ((Topo)obj) == this;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return (base.GetHashCode(), profundidadExcavada, garrasAfiladas).GetHashCode();
        }


        public override string PesoIdeal()
        {
            string rta;
            if (this.peso >= 0.050 && this.peso <= 0.080)
            {
                rta = " ";
            }
            else
            {
                rta = " no ";
            }

            return $"El topo{rta}está en su peso ideal (50g - 80g)";
        }
    }
}
