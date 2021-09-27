using Ventas_Domain.Commands;
using Ventas_Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using Ventas_Application.Services.Interface_Service;
using Ventas_Domain.Entities;
using Ventas_Domain.DTOs.VentasDtos;
using Ventas_Domain.DTOs;

namespace Ventas_Application.Services
{
    public class VentasService : IVentasService
    {
        IGenericRepository Repository;
        IVentasQuery Query;
        IQueryGeneric QueryGeneric;
        public VentasService(IGenericRepository _repository, IVentasQuery _query, IQueryGeneric xQueryGeneric)
        {
            Repository = _repository;
            Query = _query;
            QueryGeneric = xQueryGeneric;
        }



        public List<ResponseAllVentas> GetAllVentas()
        {

            List<ResponseAllVentas> ListaVentasResponse = new List<ResponseAllVentas>();
            var ListaVentas = QueryGeneric.GetAll<Ventas>();

            foreach (var Venta in ListaVentas)
            {
                ListaVentasResponse.Add(new ResponseAllVentas
                {
                    Id = Venta.Id,
                    Fecha = Venta.Fecha.ToShortDateString(),
                    Comprobante = Venta.Comprobante,
                    estado = Venta.estado,
                    CarroId = Venta.CarroId

                });

            }
            return ListaVentasResponse;

        }

        public List<ResponseGetVenta> GetVentaByFechaId(string Fecha, string VentaId)
        {

            return Query.GetVentaByFechaIdQuery(Fecha, VentaId);

        }

        public ResponseGetVenta GetVentaById(int Id)
        {
            return Query.GetVentaByIdQuery(Id);

        }

        public GenericCreatedDto CreateVenta(RequestVenta venta)
        {
            
            string[] FechaString = venta.Fecha.Split('-');
            DateTime FechaDatetime = new DateTime(int.Parse(FechaString[0]), int.Parse(FechaString[1]), int.Parse(FechaString[2]));

            var entity = new Ventas
            {
                Fecha = FechaDatetime,
                Comprobante = venta.Comprobante,
                estado = venta.estado,
                CarroId = venta.CarroId
            };

            Repository.Add<Ventas>(entity);

            return new GenericCreatedDto { Entity = "Ventas", Id = entity.Id.ToString() };

        }

    }
}
