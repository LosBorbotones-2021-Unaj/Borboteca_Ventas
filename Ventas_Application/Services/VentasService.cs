﻿using Ventas_Domain.Commands;
using Ventas_Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using Ventas_Application.Services.Interface_Service;

namespace Ventas_Application.Services
{
    public class VentasService : IVentasService
    {
        IGenericRepository Repository;
        ICarroLibroQuery query;
        public VentasService(IGenericRepository _repository, ICarroLibroQuery _query)
        {
            Repository = _repository;
            query = _query;
        }
    }
}
