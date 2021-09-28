using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ventas_Domain.Queries;

namespace Ventas_AccessData.Queries
{
    public class QueryGeneric : IQueryGeneric
    {
        private readonly VentasContext context;
        public QueryGeneric( VentasContext dbContext)
        {
            
            context = dbContext;
        }
        public List<T> GetAll<T>() where T : class 
        { 
            return (context.Set<T>()).ToList();
            
        }
    }
}
