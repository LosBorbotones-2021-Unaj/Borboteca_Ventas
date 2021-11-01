using SqlKata.Compilers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Ventas_Domain.IDatabaseValidations;

namespace Ventas_AccessData.Validations.CarroValidations
{
    public class CarroValidations : ICarroValidations
    {
        private readonly IDbConnection Connection;
        private readonly Compiler SklKataCompiler;
        private readonly VentasContext Context;
        public CarroValidations(IDbConnection _Connection, Compiler _SklKataCompiler, VentasContext DbContext)
        {
            Connection = _Connection;
            SklKataCompiler = _SklKataCompiler;
            Context = DbContext;
        }

        public string ValidateCarroId(int CarroId)
        {
            if (!Context.Carro.Any(C => C.Id == CarroId)) return "NO HAS INGRESADO UN ID DE CARRO VALIDO";

            return null;
        }

        public string ValidateUsuarioId(int UsuarioId)
        {
            if (!Context.Carro.Any(C => C.Usuarioid == UsuarioId)) return "El usuario que ingreso no esta asignada a ningun carro";

            else return null;
        }
    }
}
