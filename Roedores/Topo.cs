using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roedores
{
    public class Topo : Roedor
    {
        public double profundidadExcavada { get; set; }
        public bool garrasAfiladas { get; set; }

        public string TypeDiscriminator => "Topo";

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

        public Topo() { }

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
            sb.Append($" /// Es: Topo");

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
            if (this.peso >= 50 && this.peso <= 80)
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
