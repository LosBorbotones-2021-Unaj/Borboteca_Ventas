using Ventas_Domain.Commands;
using Ventas_Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using Ventas_Application.Services.Interface_Service;
using Ventas_Domain.Entities;
using Ventas_Domain.DTOs.VentasDtos;
using Ventas_Domain.DTOs;
using FluentValidation.Results;
using Ventas_AccessData.Validations.VentasValidations;
using Ventas_Domain.IDatabaseValidations;
using System.Linq;

namespace Ventas_Application.Services
{
    public class VentasService : IVentasService
    {
        IGenericRepository Repository;
        IVentasQuery Query;
        IQueryGeneric QueryGeneric;
        ICarroValidations CarroValidate;
        List<string> ValidacionesBaseDatos;
        public VentasService(IGenericRepository _repository, IVentasQuery _query, IQueryGeneric xQueryGeneric, ICarroValidations xCarroValidate)
        {
            Repository = _repository;
            Query = _query;
            QueryGeneric = xQueryGeneric;
            CarroValidate = xCarroValidate;
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

        public Response CreateVenta(RequestVenta venta)
        {
            CreateVentaValidation validator = new CreateVentaValidation();
            ValidationResult result = validator.Validate(venta);
            ValidacionesBaseDatos = new List<string>();
            var ListaErrores = new List<Object>();
            Ventas entity = null;
  

            if (result.IsValid)
            {
                ValidacionesBaseDatos.Add(CarroValidate.ValidateCarroId(venta.CarroId));

                if (!ValidacionesBaseDatos.Any(Error => Error != null)) 
                { 
                    string[] FechaString = venta.Fecha.Split('-');
                    DateTime FechaDatetime = new DateTime(int.Parse(FechaString[0]), int.Parse(FechaString[1]), int.Parse(FechaString[2]));

                    entity = new Ventas
                    {
                        Fecha = FechaDatetime,
                        Comprobante = venta.Comprobante,
                        estado = venta.estado,
                        CarroId = venta.CarroId
                    };

                    Repository.Add<Ventas>(entity);
                }
                else ListaErrores.AddRange(ValidacionesBaseDatos.Where(Error => Error != null));
            }
            else result.Errors.ForEach(Error => ListaErrores.Add(Error.ErrorMessage.ToString()));

            if(ListaErrores.Count != 0 ) return new Response{ IsValid =false, Errors=ListaErrores };

            return new Response { entity = "Ventas", Id = entity.Id.ToString(),Errors=null,IsValid = true };

        }

    }
}
