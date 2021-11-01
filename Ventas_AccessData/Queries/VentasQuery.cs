using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Ventas_Domain.DTOs.VentasDtos;
using Ventas_Domain.Entities;
using Ventas_Domain.Queries;

namespace Ventas_AccessData.Queries
{
    public class VentasQuery : IVentasQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler sklKataCompiler;
        private readonly VentasContext context;
        public VentasQuery(IDbConnection xconnection, Compiler xsklKataCompiler, VentasContext dbContext)
        {
            connection = xconnection;
            sklKataCompiler = xsklKataCompiler;
            context = dbContext;
        }

        public ResponseGetVenta GetVentaByIdQuery(int VentaId)
        {
            var db = new QueryFactory(connection, sklKataCompiler);

            var Venta = db.Query("Ventas")
                        .Select("Id", "Fecha", "Comprobante", "estado", "CarroId")
                        .Where("Id", "=", VentaId)
                        .FirstOrDefault<Ventas>();

            var carro = db.Query("Carro")
                        .Select("Id", "Valor", "Activo", "UsuarioId")
                        .Where("Id", "=", Venta.CarroId)
                        .FirstOrDefault<GetVentaByIdCarro>();

            return new ResponseGetVenta
            {
                Id = Venta.Id,
                Fecha = Venta.Fecha.ToShortDateString(),
                Comprobante = Venta.Comprobante,
                estado = Venta.estado,
                Carro = carro,
                IsValid = true
            };


        }



        public List<ResponseGetVenta> GetVentaByFechaIdQuery(string Fecha, string estado)
        {
            DateTime FechaDatetime = new DateTime();
            if (!string.IsNullOrWhiteSpace(Fecha))
            {
                string[] FechaString = Fecha.Split('-');
                FechaDatetime = new DateTime(int.Parse(FechaString[0]), int.Parse(FechaString[1]), int.Parse(FechaString[2]));
            }

            var db = new QueryFactory(connection, sklKataCompiler);

            List<ResponseGetVenta> ListaResponseVentas = new List<ResponseGetVenta>();

            var Ventas = (db.Query("Ventas")
                                .Select("Ventas.Id", "Ventas.Fecha", "Ventas.Comprobante", "Ventas.estado", "Ventas.CarroId")
                                .When(!string.IsNullOrWhiteSpace(estado), P => P.Where("Ventas.estado", "=", estado))
                                .When(!string.IsNullOrWhiteSpace(Fecha), x => x.Where("Ventas.Fecha", "=", FechaDatetime))).Get<Ventas>().ToList();



            foreach (var Venta in Ventas)
            {
                var carro = db.Query("Carro")
                            .Select("Id", "Valor", "Activo", "UsuarioId")
                            .Where("Id", "=", Venta.CarroId)
                            .FirstOrDefault<GetVentaByIdCarro>();

                ListaResponseVentas.Add(new ResponseGetVenta
                {

                    Id = Venta.Id,
                    Fecha = Venta.Fecha.ToShortDateString(),
                    Comprobante = Venta.Comprobante,
                    estado = Venta.estado,
                    Carro = carro

                });


            }
            return ListaResponseVentas;

        }

    }
}
