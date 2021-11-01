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
        ICarroQuery QueryCarro;
        IQueryGeneric QueryGeneric;
        public CarroLibroService(IGenericRepository _repository, ICarroLibroQuery _query, ICarroQuery _QueryCarro, IQueryGeneric xQueryGeneric)
        {
            Repository = _repository;
            Query = _query;
            QueryCarro = _QueryCarro;
            QueryGeneric = xQueryGeneric;
        }
        
        public Response CreateCarroLibro(RequestCarroLibro carroLibro)
        {

            int CarroId = QueryCarro.GetCarroByUsuarioId(carroLibro.Usuarioid);

            var entity = new CarroLibro
            {
                Carroid = CarroId, 
                Libroid = Guid.Parse(carroLibro.Libroid)
            };

            Repository.Add<CarroLibro>(entity);

            return new Response { entity = "CarroLibro", Id = entity.Id.ToString() };
        }

        public Response DeleteCarroLibro(int Id)
        {
            Repository.Delete<CarroLibro>(Id);

            return new Response { };
        }
    }
}