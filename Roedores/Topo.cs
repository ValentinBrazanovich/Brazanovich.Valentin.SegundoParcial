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


        public Topo(string nombre, double peso, ETipoAlimentacion tipoAlimetacion, double profundidadExcavada, bool garrasAfiladas)
            : base(nombre, peso, tipoAlimetacion)
        {
            this.profundidadExcavada = profundidadExcavada;
            this.garrasAfiladas = garrasAfiladas;
        }

        public Topo(string nombre, ETipoAlimentacion tipoAlimetacion, double profundidadExcavada, bool garrasAfiladas)
            : base(nombre, tipoAlimetacion)
        {
            this.profundidadExcavada = profundidadExcavada;
            this.garrasAfiladas = garrasAfiladas;
        }

        public Topo(string nombre, bool garrasAfiladas)
            : base(nombre)
        {
            this.profundidadExcavada = 5.0;
            this.garrasAfiladas = garrasAfiladas;
        }


        public override string obtenerSonido()
        {
            return "Gruñido";
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString()).Append(" - ");
            sb.Append($"Profundidad excavada: {this.profundidadExcavada}cm - ");
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
