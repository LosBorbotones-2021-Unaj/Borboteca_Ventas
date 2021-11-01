using System;
using System.Collections.Generic;
using System.Text;

namespace Ventas_Domain.IDatabaseValidations
{
    public interface IVentasValidations
    {
        string ValidateFechaVenta(string Fecha);
    }
}
