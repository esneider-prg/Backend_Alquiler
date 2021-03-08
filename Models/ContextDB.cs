using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Alquiler.Models
{
    public class ContextDB : DbContext
    {

        public ContextDB(DbContextOptions<ContextDB> options)
               : base(options)
        {

        }
        
        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Alquiler>Alquileres { get; set; }

        public DbSet<Cd> Cds { get; set; }

        public DbSet<DetalleAlquiler> DetalleAlquileres { get; set; }

        public DbSet<Titulo> Titulos { get; set; }

        public DbSet<Sancion> Sanciones { get; set; }


    }
}
