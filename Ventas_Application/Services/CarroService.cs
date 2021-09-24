using Ventas_Domain.Commands;
using Ventas_Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using Ventas_Application.Services.Interface_Service;
using Ventas_Domain.DTOs;
using Ventas_Domain.DTOs.CarroDtos;
using Ventas_Domain.Entities;

namespace Ventas_Application.Services
{
    public class CarroService : ICarroService
    {
        IGenericRepository Repository;
        ICarroQuery query;
        public CarroService(IGenericRepository _repository, ICarroQuery _query)
        {
            Repository = _repository;
            query = _query;
        }

        public GenericCreatedDto CreateCarro(RequestCarro carro)
        {
            var entity = new Carro
            {
                Valor = carro.Valor,
                Activo = carro.Activo,
                Usuarioid = carro.Usuarioid

            };

            Repository.Add<Carro>(entity);

            return new GenericCreatedDto { Entity = "Carro", Id = entity.Id.ToString() };
        }
    }
}
