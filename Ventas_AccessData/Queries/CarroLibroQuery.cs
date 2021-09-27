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

        public List<CarroLibro> GetAllCarroLibrosQuery()
        {
            return context.CarroLibro.Select(cl => new CarroLibro { Id = cl.Id, Carroid = cl.Carroid, Libroid = cl.Libroid}).ToList();
        }

        public ResponseGetCarroLibro GetCarroLibroByIdQuery(int CarroLibroId)
        {
            var db = new QueryFactory(connection, sklKataCompiler);

            var CarroLibro = db.Query("CarroLibro")
                        .Select("Id", "Libroid", "Carroid")
                        .Where("Id", "=", CarroLibroId)
                        .FirstOrDefault<CarroLibro>();

            return new ResponseGetCarroLibro
            {
                Id = CarroLibro.Id,
                Carroid = CarroLibro.Carroid,
                Libroid = CarroLibro.Libroid
            };
        }
    }
}
