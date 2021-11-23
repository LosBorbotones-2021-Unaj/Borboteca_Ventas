using SqlKata.Compilers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas_Domain.IDatabaseValidations;

namespace Ventas_AccessData.Validations.CarroLibroValidations
{
    public class CarroLibroValidations : ICarroLibroValidations
    {
        private readonly IDbConnection Connection;
        private readonly Compiler SklKataCompiler;
        private readonly VentasContext Context;
        public CarroLibroValidations(IDbConnection _Connection, Compiler _SklKataCompiler, VentasContext DbContext)
        {
            Connection = _Connection;
            SklKataCompiler = _SklKataCompiler;
            Context = DbContext;
        }

        public string LibroAlreadyExist(int CarroId, Guid Libroid)
        {
            var CarroLibro = Context.CarroLibro.Where(CL => CL.Carroid == CarroId && CL.Libroid == Libroid).FirstOrDefault();

            if (CarroLibro != null) return "El libro ya esta agregado al carrito";

            else return null;
        }
    }
}
