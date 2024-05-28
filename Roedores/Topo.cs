using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roedores
{
    public class Topo : Roedor
    {
        private double profundidadExcavada;
        private bool garrasAfiladas;

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

        public Topo() {
            this.profundidadExcavada = 0;
            this.garrasAfiladas = false;
        }

        public double ProfundidadExcavada
        {
            get { return profundidadExcavada; }
            set { profundidadExcavada = value; }
        }

        public bool GarrasAfiladas
        {
            get { return garrasAfiladas; }
            set { garrasAfiladas = value; }
        }


        public override string obtenerSonido()
        {
            return "Gruñido";
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString()).Append(" - ");
            sb.Append($"Profundidad excavada: {ProfundidadExcavada}cm - ");
            sb.Append($"Garras afiladas: {GarrasAfiladas}");
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
            return (base.GetHashCode(), ProfundidadExcavada, GarrasAfiladas).GetHashCode();
        }


        public override string PesoIdeal()
        {
            string rta;
            if (this.Peso >= 50 && this.Peso <= 80)
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
