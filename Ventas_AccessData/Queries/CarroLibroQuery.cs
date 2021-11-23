using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Ventas_Domain.DTOs.CarroLibroDtos;
using Ventas_Domain.Entities;
using Ventas_Domain.Queries;

namespace Ventas_AccessData.Queries
{
    public class CarroLibroQuery : ICarroLibroQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler sklKataCompiler;
        private readonly VentasContext context;
        public CarroLibroQuery(IDbConnection xconnection, Compiler xsklKataCompiler, VentasContext dbContext)
        {
            connection = xconnection;
            sklKataCompiler = xsklKataCompiler;
            context = dbContext;
        }

        public CarroLibro GetCarroLibro(int CarroId, Guid Libroid)
        {
            return context.CarroLibro.Where(CL => CL.Carroid == CarroId && CL.Libroid == Libroid).FirstOrDefault();
        }

        public bool GetLibrosByCarroId(int CarroId)
        {
           

            var Libros =(from CL in context.CarroLibro             
                        where CL.Carroid == CarroId
                        group CL by CL.Carroid into Ids
                        select new { LibrosDeLCarro = Ids.Count() }).FirstOrDefault();

            if (Libros == null) return true;

            else return false;
        }

    }
}