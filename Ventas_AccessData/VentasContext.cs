using Ventas_AccessData.Configurations;
using Ventas_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ventas_AccessData
{
    public class VentasContext : DbContext
    {
        public VentasContext(DbContextOptions<VentasContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

          
            new ConfigCarroLibro(modelBuilder.Entity<CarroLibro>());
            new ConfigCarro(modelBuilder.Entity<Carro>());
            new ConfigVentas(modelBuilder.Entity<Ventas>());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<CarroLibro> CarroLibro { get; set; }
        public DbSet<Ventas> Ventas { get; set; }
        public DbSet<Carro> Carro { get; set; }

    }

}
