using System.Text;
using System.Xml.Serialization;

namespace Roedores
{
    [XmlInclude(typeof(Hamster))]
    [XmlInclude(typeof(Raton))]
    [XmlInclude(typeof(Topo))]
    public abstract class Roedor
    {
        public string nombre { get; set; }
        public double peso { get; set; }
        public ETipoAlimentacion tipoAlimentacion { get; set; }

        /// <summary>
        /// Constructor de la clase padre Roedor
        /// </summary>
        /// <param name="nombre"> El nombre del roedor</param>
        /// <param name="peso"> El peso del roedor</param>
        /// <param name="tipoAlimentacion"> El tipo de alimentacion del roedor</param>
        public Roedor(string nombre, double peso, ETipoAlimentacion tipoAlimentacion)
        {
            this.nombre = nombre;
            this.peso = peso;
            this.tipoAlimentacion = tipoAlimentacion;
        }

        public Roedor(string nombre, ETipoAlimentacion tipoAlimentacion) 
            : this(nombre, 50, tipoAlimentacion)
        {
        }
        public Roedor(string nombre) : this(nombre, 50, ETipoAlimentacion.Omnivoro)
        {
        }

        public Roedor() { }

        public abstract string obtenerSonido();

        public virtual string moverCola()
        {
            return "El roedor mueve su pequeña cola";
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Nombre: {this.nombre} - ");
            sb.Append($"Peso: {this.peso}g - ");
            sb.Append($"Alimentación: {this.tipoAlimentacion}");

            return sb.ToString();
        }

        public override bool Equals(object? obj)
        {
            if (obj is Roedor && obj != null)
            {
                return ((Roedor)obj) == this;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return (nombre, peso, tipoAlimentacion).GetHashCode();
        }


        public static bool operator ==(Roedor r, Roedor r1)
        {
            // Si ambos son nulos, o si son la misma instancia, entonces son iguales
            if (ReferenceEquals(r, r1))
            {
                return true;
            }

            // Si uno de ellos es nulo, o si son de diferentes tipos, entonces no son iguales
            if (ReferenceEquals(r, null) || ReferenceEquals(r1, null) || r.GetType() != r1.GetType())
            {
                return false;
            }

            // Compara las propiedades relevantes para determinar la igualdad
            return r.nombre == r1.nombre && r.peso == r1.peso && r.tipoAlimentacion == r1.tipoAlimentacion;
        }

        public static bool operator !=(Roedor r, Roedor r1)
        {
            return !(r == r1);
        }


        public abstract string PesoIdeal();

    }
}
