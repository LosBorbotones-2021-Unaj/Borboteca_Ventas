using System;
using System.Collections.Generic;
using System.Text;
using Ventas_Domain.DTOs.CarroLibroDtos;
using Ventas_Domain.Entities;

namespace Ventas_Domain.Queries
{
    public interface ICarroLibroQuery
    {
        bool GetLibrosByCarroId(int CarroId);

        CarroLibro GetCarroLibro(int CarroId, Guid Libroid);
    }
}

