using System.Text;
using System.Xml.Serialization;

namespace Roedores
{
    // Indico que que estas 3 clases son subtipos de la clase serializada o deserializada en XML.
    [XmlInclude(typeof(Hamster))]
    [XmlInclude(typeof(Raton))]
    [XmlInclude(typeof(Topo))]
    public abstract class Roedor
    {
        private string nombre;
        private double peso;
        private ETipoAlimentacion tipoAlimentacion;

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

        public virtual string MoverCola()
        {
            return "El roedor mueve su cola";
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
            if (ReferenceEquals(r, r1))
            {
                return true;
            }

            if (ReferenceEquals(r, null) || ReferenceEquals(r1, null) || r.GetType() != r1.GetType())
            {
                return false;
            }

            return r.Nombre == r1.Nombre && r.Peso == r1.Peso && r.TipoAlimentacion == r1.TipoAlimentacion;
        }

        public static bool operator !=(Roedor r, Roedor r1)
        {
            return !(r == r1);
        }

        public abstract string ObtenerSonido();
        public abstract string PesoIdeal();

    }
}
