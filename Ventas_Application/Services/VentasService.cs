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
        IVentasQuery query;
        public VentasService(IGenericRepository _repository, IVentasQuery _query)
        {
            Repository = _repository;
            query = _query;
        }

        public List<ResponseAllVentas> GetAllVentas()
        {
             List<ResponseAllVentas> ListaVentasResponse=new List<ResponseAllVentas>();
             var ListaVentas = query.GetAllVentasQuery();
            foreach(var Venta in ListaVentas)
             {
                ListaVentasResponse.Add(new ResponseAllVentas
                {
                    Id = Venta.Id,
                    Fecha = Venta.Fecha.ToShortDateString(),
                    Comprobante=Venta.Comprobante,
                    estado=Venta.estado,
                    CarroId=Venta.CarroId

                });
                
             }
            return ListaVentasResponse;

        }

        public List<ResponseGetVenta> GetVentaByFechaId(DateTime fecha, int id)
        {
            return query.GetVentaByFechaIdQuery(fecha, id);
            
        }

        public ResponseGetVenta GetVentaById(int Id)
        {
            return query.GetVentaByIdQuery(Id);
            
        }

        public GenericCreatedDto CreateVenta(RequestVenta venta)
        {
            string[] FechaString = venta.Fecha.Split('-'); //Se podría cambiar a /
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
