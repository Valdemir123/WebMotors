using AnuncioWebMotors.Models;
using Microsoft.EntityFrameworkCore;

namespace AnuncioWebMotors.Data
{
    public class AnuncioWebMotorsContext : DbContext
    {
        public AnuncioWebMotorsContext (DbContextOptions<AnuncioWebMotorsContext> options) : base(options) { }
        
        // tabelas
        public DbSet<Class_Anuncio>         Class_Anuncio { get; set; }
        
        // tabelas
        public DbSet<AnuncioWebMotors.Models.Class_Mercado> Class_Mercado { get; set; }
    }
}
