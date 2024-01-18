using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TRABALHOELETROPONTO.Models;
using Microsoft.EntityFrameworkCore;
namespace TRABALHOELETROPONTO.Data
{
  public class ProdutoContext : DbContext
    {
        public ProdutoContext(DbContextOptions<ProdutoContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produto { get; set; }

      
    }
}