using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TRABALHOELETROPONTO.Models;
using Microsoft.EntityFrameworkCore;
namespace TRABALHOELETROPONTO.Data
{
  public class VendaContext : DbContext
    {
        public VendaContext(DbContextOptions<VendaContext> options) : base(options)
        {
        }

        public DbSet<Venda> Venda { get; set; }

      
    }
}