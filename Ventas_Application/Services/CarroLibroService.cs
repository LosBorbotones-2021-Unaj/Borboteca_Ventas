using Ventas_Domain.Commands;
using Ventas_Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using Ventas_Application.Services.Interface_Service;

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
    } 
}
