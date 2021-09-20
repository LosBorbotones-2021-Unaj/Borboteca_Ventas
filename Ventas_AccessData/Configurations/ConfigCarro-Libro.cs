
using Ventas_Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas_AccessData.Configurations
{
    class ConfigCarroLibro
    {
        public ConfigCarroLibro(EntityTypeBuilder<CarroLibro> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);


        }
    }
}
