using System.Text;
using System.Xml.Serialization;

namespace Roedores
{
    [XmlInclude(typeof(Hamster))]
    [XmlInclude(typeof(Raton))]
    [XmlInclude(typeof(Topo))]
    public abstract class Roedor
    {
        private string nombre;
        private double peso;
        private ETipoAlimentacion tipoAlimentacion;

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

        public Roedor() {
            this.nombre = "sin nombre";
            this.peso = 0;
            this.tipoAlimentacion = ETipoAlimentacion.Omnivoro;
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public double Peso
        {
            get { return peso; }
            set { peso = value; }
        }

        public ETipoAlimentacion TipoAlimentacion
        {
            get { return tipoAlimentacion; }
            set {  tipoAlimentacion = value; }
        }

        public abstract string obtenerSonido();

        public virtual string moverCola()
        {
            return "El roedor mueve su pequeña cola";
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Nombre: {Nombre} - ");
            sb.Append($"Peso: {Peso}g - ");
            sb.Append($"Alimentación: {TipoAlimentacion}");

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
            return (Nombre, Peso, TipoAlimentacion).GetHashCode();
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
            return r.Nombre == r1.Nombre && r.Peso == r1.Peso && r.TipoAlimentacion == r1.TipoAlimentacion;
        }

        public static bool operator !=(Roedor r, Roedor r1)
        {
            return !(r == r1);
        }


        public abstract string PesoIdeal();

    }
}
