using TRABALHOELETROPONTO.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TRABALHOELETROPONTO.Data
{
   public class ClienteContext : IdentityDbContext<Cliente>
    {
         public ClienteContext(DbContextOptions<ClienteContext> options) : base(options){
            
        }
        public DbSet<Cliente> Cliente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cliente>().HasData(
                new Cliente
                {
                    ID_CLIENTE = 1,
                    NOME_CLI= "joaozinho",
                    Email = "joao@gmail.com",
                    TELEFONE = "23",
                    ENDERECO = "senha",
                    PasswordHash = "Senha@123"

                }
            );
        }
    }
}