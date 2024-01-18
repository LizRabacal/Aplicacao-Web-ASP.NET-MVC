using Microsoft.EntityFrameworkCore;
using TRABALHOELETROPONTO.Models;

namespace TRABALHOELETROPONTO.Data
{
    public class FuncionarioContext : DbContext
    {
        public FuncionarioContext(DbContextOptions<FuncionarioContext> options) : base(options)
        {
        }

        public DbSet<Funcionario> Funcionario { get; set; }

      
    }
}
