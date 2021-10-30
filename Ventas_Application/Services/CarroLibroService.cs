using Ventas_Domain.Commands;
using Ventas_Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using Ventas_Application.Services.Interface_Service;
using Ventas_Domain.DTOs;
using Ventas_Domain.DTOs.CarroLibroDtos;
using Ventas_Domain.Entities;

namespace Ventas_Application.Services
{
    public class CarroLibroService : ICarroLibroService
    {

        IGenericRepository Repository;
        ICarroLibroQuery Query;
        IQueryGeneric QueryGeneric;
        public CarroLibroService(IGenericRepository _repository, ICarroLibroQuery _query, IQueryGeneric xQueryGeneric)
        {
            Repository = _repository;
            Query = _query;
            QueryGeneric = xQueryGeneric;
        }
        
        public GenericCreatedDto CreateCarroLibro(RequestCarroLibro carroLibro)
        {
            var entity = new CarroLibro
            {
                Carroid = carroLibro.Carroid, 
                Libroid = carroLibro.Libroid
            };

            Repository.Add<CarroLibro>(entity);

            return new GenericCreatedDto { Entity = "CarroLibro", Id = entity.Id.ToString() };
        }

        public Response DeleteCarroLibro(int Id)
        {
            Repository.Delete<CarroLibro>(Id);

            return new Response { };
        }
    }
}