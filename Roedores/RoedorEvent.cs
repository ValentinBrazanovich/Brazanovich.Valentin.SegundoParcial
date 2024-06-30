using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public delegate void RoedorEventHandler(object sender, RoedorEvent e);

    public class RoedorEvent : EventArgs
    {
        public string accion;
        public Roedor roedor;

        public RoedorEvent(string accion, Roedor roedor)
        {
            this.accion = accion;
            this.roedor = roedor;
        }


    }
}
