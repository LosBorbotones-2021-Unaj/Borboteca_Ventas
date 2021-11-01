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
        ICarroValidations CarroValidateDB;
        IVentasValidations VentasValidationDB;
        List<string> ValidacionesBaseDatos;
        public VentasService(IGenericRepository _repository, IVentasQuery _query, IQueryGeneric xQueryGeneric, ICarroValidations xCarroValidate,IVentasValidations xVentasValidationDB)
        {
            Repository = _repository;
            Query = _query;
            QueryGeneric = xQueryGeneric;
            CarroValidateDB = xCarroValidate;
            VentasValidationDB = xVentasValidationDB;
        }
     

        public List<ResponseGetVenta> GetVentaByFechaId(string Fecha, string estado)
        {
            VentaByFechaIDValidation validator = new VentaByFechaIDValidation();
            ValidationResult result = validator.Validate(new VentasValidate(Fecha,estado));
            ValidacionesBaseDatos = new List<string>();
            var ListaErrores = new List<Object>();
            var Lista = new List<ResponseGetVenta>();

            if (result.IsValid)
            {
                ValidacionesBaseDatos.Add(VentasValidationDB.ValidateFechaVenta(Fecha));

                if (!ValidacionesBaseDatos.Any(Error => Error != null))
                {
                   Lista =  Query.GetVentaByFechaIdQuery(Fecha, estado);
                }

                else ListaErrores.AddRange(ValidacionesBaseDatos.Where(Error => Error != null));
            }
            else result.Errors.ForEach(Error => ListaErrores.Add(Error.ErrorMessage.ToString()));


            if (ListaErrores.Count != 0) Lista.Add(new ResponseGetVenta { IsValid = false, Errors = ListaErrores });
                          
            return Lista;
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
                ValidacionesBaseDatos.Add(CarroValidateDB.ValidateCarroId(venta.CarroId));

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
