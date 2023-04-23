using Microsoft.EntityFrameworkCore;
using SistemaDeCadastroJogos.Data.Map;
using SistemaDeCadastroJogos.Model;

namespace SistemaDeCadastroJogos.Data
{
    public class SistemaTarefasDBContex : DbContext
    {

        public SistemaTarefasDBContex(DbContextOptions<SistemaTarefasDBContex> options): base(options)
        {
        
        
        }

        public DbSet<JogoModel> Jogos { get; set; }
        public DbSet<GeneroModel> Generos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new JogoMap());
            modelBuilder.ApplyConfiguration(new GeneroMap());
            base.OnModelCreating(modelBuilder);
        }

    }
}
