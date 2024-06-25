using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roedores
{
    public interface IPesoPromedio
    {
        double CalcularPesoPromedio<T>() where T : Roedor;
    }
}
