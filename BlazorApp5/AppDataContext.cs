using BlazorApp5.Classes;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp5
{
    public class AppDataContext: DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> option) :base(option) {}

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Fornecedor> Fornecedore { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<NotaFiscal> NotaFiscals { get; set; }
    }
}
