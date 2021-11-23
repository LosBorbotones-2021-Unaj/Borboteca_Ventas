using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas_Domain.IDatabaseValidations
{
    public interface ICarroLibroValidations
    {
        public string LibroAlreadyExist(int CarroId, Guid Libroid);
    }
}
