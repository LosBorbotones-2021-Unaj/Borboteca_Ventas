﻿using Ventas_Domain.Commands;
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
        ICarroLibroQuery query;
        public CarroLibroService(IGenericRepository _repository, ICarroLibroQuery _query)
        {
            Repository = _repository;
            query = _query;
        }

        public List<ResponseAllCarroLibro> GetAllCarroLibros()
        {
            List<ResponseAllCarroLibro> ListaCarroLibroResponse = new List<ResponseAllCarroLibro>();
            var ListaCarroLibro = query.GetAllCarroLibrosQuery();
            foreach (var CarroLibro in ListaCarroLibro)
            {
                ListaCarroLibroResponse.Add(new ResponseAllCarroLibro
                {
                    Id = CarroLibro.Id,
                    Carroid = CarroLibro.Carroid,
                    Libroid = CarroLibro.Libroid
                });
            }
            return ListaCarroLibroResponse;
        }

        public ResponseGetCarroLibro GetCarroLibroById(int Id)
        {
            return query.GetCarroLibroByIdQuery(Id);
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



    }
}
