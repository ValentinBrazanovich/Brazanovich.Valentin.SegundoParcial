using System.Text;

namespace Roedores
{
    public abstract class Roedor
    {
        public string nombre;
        public double peso;
        public ETipoAlimentacion tipoAlimentacion;

        //public protected abstract List<Pasajero> Pasajeros {  get; }

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
            : this(nombre, 0.050, tipoAlimentacion)
        {
        }
        public Roedor(string nombre) : this(nombre, 0.050, ETipoAlimentacion.Omnivoro)
        {
        }


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
            if (r.nombre == r1.nombre && r.peso == r1.peso && r.tipoAlimentacion == r1.tipoAlimentacion)
            {
                return true;
            }

            return r.Equals(r1);
        }

        public static bool operator !=(Roedor r, Roedor r1)
        {
            return !(r == r1);
        }


        public abstract string PesoIdeal();

    }
}
