using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SolucaoSimpar2.Models;

namespace SolucaoSimpar2.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {



        }

        public DbSet<Motorista> Motoristas { get; set; }
        public DbSet<Caminhao> Caminhoes { get; set; }
        public DbSet<Viagem> Viagem { get; set; }

    }
}
