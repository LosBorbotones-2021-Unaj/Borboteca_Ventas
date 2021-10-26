using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas_Domain.Entities
{
    public class CarroLibro
    {
        public int Id { get; set; }

        public Guid Libroid { get; set; }
        public int Carroid { get; set; }
        public Carro Carro { get; set; }
    }
}
