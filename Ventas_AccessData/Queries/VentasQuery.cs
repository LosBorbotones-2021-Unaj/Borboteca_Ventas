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

        public bool ExistVentaActive(int CarroId)
        {
            var Venta = context.Ventas.Where(V => V.CarroId == CarroId).FirstOrDefault();

            if (Venta != null) return false;

            return true;
        }

        

        public Ventas GetVentaByCarroIdQuery(int CarroId)
        {
            var db = new QueryFactory(connection, sklKataCompiler);

            var Venta = context.Ventas.Where(V => V.CarroId == CarroId).FirstOrDefault();

            return new Ventas
            {
                Id = Venta.Id,
                Fecha = Venta.Fecha,
                Comprobante = Venta.Comprobante,
                estado = false,
                CarroId = CarroId
            };

        }


        public List<ResponseGetVenta> GetVentaByFechaEstadoQuery(int UsuarioId, string Fecha, string estado)
        {
            string mensajeEstado = "";
            DateTime FechaDatetime = new DateTime();
            if (!string.IsNullOrWhiteSpace(Fecha))
            {
                string[] FechaString = Fecha.Split('-');
                FechaDatetime = new DateTime(int.Parse(FechaString[0]), int.Parse(FechaString[1]), int.Parse(FechaString[2]));
            }

            var db = new QueryFactory(connection, sklKataCompiler);

            List<ResponseGetVenta> ListaResponseVentas = new List<ResponseGetVenta>();
            List<int> LibrosId = new List<int>();
    

            var ListaVentas = (db.Query("Ventas")
                               .Select("Ventas.Id", "Ventas.Fecha", "Ventas.Comprobante", "Ventas.estado", "Ventas.CarroId")
                               .Join("Carro", "Carro.Id", "Ventas.CarroId")
                               .Where("Carro.UsuarioId", "=" ,UsuarioId)
                               .When(!string.IsNullOrWhiteSpace(estado), P => P.Where("Ventas.estado", "=", estado))
                               .When(!string.IsNullOrWhiteSpace(Fecha), x => x.Where("Ventas.Fecha", "=", FechaDatetime))).Get<Ventas>().ToList();

            if (ListaVentas != null)
            {
                foreach (var Venta in ListaVentas)
                {

                    var cadaVenta = (from CL in context.CarroLibro
                                     join C in context.Carro on CL.Carroid equals C.Id
                                     into union_CL_C
                                     from CL_C in union_CL_C.DefaultIfEmpty()
                                     join V in context.Ventas on CL_C.Id equals V.CarroId
                                     into union_CL_C_V
                                     from CL_C_V in union_CL_C_V.DefaultIfEmpty()
                                     where CL_C_V.Id == Venta.Id
                                     select CL.Libroid).ToList();

                    if (Venta.estado == false) mensajeEstado = "Finalizada";
                    else mensajeEstado = "Activa";
                    ListaResponseVentas.Add(new ResponseGetVenta
                    {

                        Id = Venta.Id,
                        Fecha = Venta.Fecha.ToShortDateString(),
                        Comprobante = Venta.Comprobante,
                        estado = mensajeEstado,
                        LibrosId = cadaVenta

                    });


                }

            }
            return ListaResponseVentas;

        }

        public List<string> GetAllVentasQuery(int UsuarioId)
        {
            var ListaAllVentas = (from C in context.Carro
                                  join V in context.Ventas on C.Id equals V.CarroId
                                  into union_C_V
                                  from C_V in union_C_V.DefaultIfEmpty()
                                  where C.Usuarioid == UsuarioId && C_V.CarroId == C.Id
                                  select C_V.Fecha.ToShortDateString()).DefaultIfEmpty();

            
            return ListaAllVentas.ToList();
        }

    }
}
