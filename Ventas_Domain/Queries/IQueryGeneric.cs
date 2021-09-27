using System;
using System.Collections.Generic;
using System.Text;

namespace Ventas_Domain.Queries
{
    public interface IQueryGeneric
    {
        List<T> GetAll<T>() where T : class;
    }
}
