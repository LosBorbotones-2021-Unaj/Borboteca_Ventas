using NPOI.SS.Util;
using SqlKata.Compilers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Ventas_Domain.IDatabaseValidations;

namespace Ventas_AccessData.Validations.VentasValidations
{
    public class VentasValidations : IVentasValidations
    {

        private readonly IDbConnection Connection;
        private readonly Compiler SklKataCompiler;
        private readonly VentasContext Context;
        public VentasValidations(IDbConnection _Connection, Compiler _SklKataCompiler, VentasContext DbContext)
        {
            Connection = _Connection;
            SklKataCompiler = _SklKataCompiler;
            Context = DbContext;
        }

        public string ValidateFechaVenta(string Fecha)
        {
            DateTime FechaDateTime;
            SimpleDateFormat Formato = new SimpleDateFormat("yyyy-mm-dd");
            FechaDateTime = Formato.Parse(Fecha);
            if (!Context.Ventas.Any(V => V.Fecha == FechaDateTime)) return "La fecha que ingreso no esta asignada a ninguna venta";
            else return null;
        }
        
    }
}
