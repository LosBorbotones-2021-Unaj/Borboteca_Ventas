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
        ICarroQuery QueryCarro;
        IQueryGeneric QueryGeneric;
        ICarroValidations CarroValidateDB;
        IVentasValidations VentasValidationDB;
        List<string> ValidacionesBaseDatos;
        public VentasService(IGenericRepository _repository, IVentasQuery _query, ICarroQuery _QueryCarro, IQueryGeneric xQueryGeneric, ICarroValidations xCarroValidate, IVentasValidations xVentasValidationDB)
        {
            Repository = _repository;
            Query = _query;
            QueryCarro = _QueryCarro;
            QueryGeneric = xQueryGeneric;
            CarroValidateDB = xCarroValidate;
            VentasValidationDB = xVentasValidationDB;
        }


        public List<ResponseGetVenta> GetVentasByFechaEstado(int UsuarioId,string Fecha, string estado)
        {
            VentaByFechaIDValidation validator = new VentaByFechaIDValidation();
            ValidationResult result = validator.Validate(new VentasValidate(Fecha, estado));
            ValidacionesBaseDatos = new List<string>();
            var ListaErrores = new List<Object>();
            var ListaResponseVentas = new List<ResponseGetVenta>();

            if (result.IsValid)
            {
                ValidacionesBaseDatos.Add(VentasValidationDB.ValidateFechaVenta(Fecha));

                if (!ValidacionesBaseDatos.Any(Error => Error != null))
                {
                    ListaResponseVentas = Query.GetVentaByFechaEstadoQuery(UsuarioId, Fecha, estado);
                }

                else ListaErrores.AddRange(ValidacionesBaseDatos.Where(Error => Error != null));
            }
            else result.Errors.ForEach(Error => ListaErrores.Add(Error.ErrorMessage.ToString()));


            if (ListaErrores.Count != 0) ListaResponseVentas.Add(new ResponseGetVenta { IsValid = false, Errors = ListaErrores });

            return ListaResponseVentas;
        }



        public Response CreateVenta(int UsuarioId)
        {
            ValidacionesBaseDatos = new List<string>();
            var ListaErrores = new List<Object>();
            Ventas entity = null;



            ValidacionesBaseDatos.Add(CarroValidateDB.ValidateUsuarioId(UsuarioId));


            if (!ValidacionesBaseDatos.Any(Error => Error != null))
            {

                var CarroId = QueryCarro.GetCarroByUsuarioId(UsuarioId);

                if (Query.ExistVentaActive(CarroId))  
                {
                    entity = new Ventas
                    {
                        Fecha = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day),
                        Comprobante = "",
                        estado = true,
                        CarroId = CarroId
                    };

                    Repository.Add<Ventas>(entity);


                }
                else return new Response { IsValid = true };
            }
            else ListaErrores.AddRange(ValidacionesBaseDatos.Where(Error => Error != null));

            if (ListaErrores.Count != 0) return new Response { IsValid = false, Errors = ListaErrores };

            return new Response { entity = "Ventas", Id = entity.Id.ToString(), Errors = null, IsValid = true };

        }

        public Ventas VentaCerrada(int UsuarioId)
        {
            var CarroId = QueryCarro.GetCarroByUsuarioId(UsuarioId);

            var ResponseVenta = Query.GetVentaByCarroIdQuery(CarroId);

            Repository.Update(ResponseVenta.Id, ResponseVenta);

            return ResponseVenta;


        }

        public Response DeleteVenta(int UsuarioId)
        {
            ValidacionesBaseDatos = new List<string>();
            var ListaErrores = new List<Object>();


            ValidacionesBaseDatos.Add(CarroValidateDB.ValidateUsuarioId(UsuarioId));


            if (!ValidacionesBaseDatos.Any(Error => Error != null))
            {
                var CarroId = QueryCarro.GetCarroByUsuarioId(UsuarioId);

                var ResponseVenta = Query.GetVentaByCarroIdQuery(CarroId);

                Repository.Delete<Ventas>(ResponseVenta.Id);

                return new Response { IsValid = true };
            }
            else ListaErrores.AddRange(ValidacionesBaseDatos);

            return new Response { IsValid = false, Errors = ListaErrores };

        }

        public List<string> GetAllVentas(int UsuarioId)
        {
            return Query.GetAllVentasQuery(UsuarioId);
        }
    }
}
