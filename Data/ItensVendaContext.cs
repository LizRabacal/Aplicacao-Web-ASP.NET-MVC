using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TRABALHOELETROPONTO.Models;
using Microsoft.EntityFrameworkCore;
namespace TRABALHOELETROPONTO.Data
{
  public class ItensVendaContext : DbContext
    {
        public ItensVendaContext(DbContextOptions<ItensVendaContext> options) : base(options)
        {
        }

        public DbSet<ItensVenda> ItensVenda { get; set; }

      
    }
}