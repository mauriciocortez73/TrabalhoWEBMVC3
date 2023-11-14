using Microsoft.EntityFrameworkCore;

namespace TrabalhoWEBMVC3.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Empresa> Empresas { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Impressora> Impressoras { get; set; }

        public DbSet<Tonner> Tonners { get; set; }

        public DbSet<Pedido> Pedidos { get; set; }
    }
}
