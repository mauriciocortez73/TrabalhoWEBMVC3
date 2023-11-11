using Microsoft.EntityFrameworkCore;

namespace TrabalhoWEBMVC3.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Empresa> Empresas { get; set; }
    }
}
