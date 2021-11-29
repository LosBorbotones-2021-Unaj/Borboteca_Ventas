using Ventas_Domain.Commands;
using Ventas_Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using Ventas_Application.Services.Interface_Service;
using Ventas_Domain.DTOs;
using Ventas_Domain.DTOs.CarroLibroDtos;
using Ventas_Domain.Entities;
using Ventas_Domain.IDatabaseValidations;
using System.Linq;

namespace Ventas_Application.Services
{
    public class CarroLibroService : ICarroLibroService
    {

        IGenericRepository Repository;
        ICarroLibroQuery Query;
        ICarroQuery QueryCarro;
        IQueryGeneric QueryGeneric;
        ICarroLibroValidations CarroLibroValidationDB;
        List<string> ValidacionesBaseDatos;
        public CarroLibroService(IGenericRepository _repository, ICarroLibroQuery _query, ICarroQuery _QueryCarro, IQueryGeneric xQueryGeneric, ICarroLibroValidations _CarroLibroValidationDB)
        {
            Repository = _repository;
            Query = _query;
            QueryCarro = _QueryCarro;
            QueryGeneric = xQueryGeneric;
            CarroLibroValidationDB = _CarroLibroValidationDB;
        }

        public ResponseGetCarroLibro CreateCarroLibro(RequestCarroLibro carroLibro)
        {
            ValidacionesBaseDatos = new List<string>();
            var ListaErrores = new List<Object>();

            int CarroId = QueryCarro.GetCarroByUsuarioId(carroLibro.Usuarioid);
            ValidacionesBaseDatos.Add(CarroLibroValidationDB.LibroAlreadyExist(CarroId, Guid.Parse(carroLibro.Libroid)));

            if (!ValidacionesBaseDatos.Any(Error => Error != null))
            {
                var entity = new CarroLibro
                {
                    Carroid = CarroId,
                    Libroid = Guid.Parse(carroLibro.Libroid)
                };

                Repository.Add<CarroLibro>(entity);

                return new ResponseGetCarroLibro { IsValid = true, Libroid = entity.Libroid };
            }
            else ListaErrores.AddRange(ValidacionesBaseDatos);

            return new ResponseGetCarroLibro { IsValid = false, Errors = ListaErrores };

        }

        public Response DeleteCarroLibro(RequestCarroLibro CarroLibro)
        {
            int CarroId = QueryCarro.GetCarroByUsuarioId(CarroLibro.Usuarioid);

            CarroLibro CarroLibroToDelete = Query.GetCarroLibro(CarroId, Guid.Parse(CarroLibro.Libroid));

            if(CarroLibroToDelete != null)
                Repository.Delete<CarroLibro>(CarroLibroToDelete.Id);

            return new Response { };
        }

        
    }
}