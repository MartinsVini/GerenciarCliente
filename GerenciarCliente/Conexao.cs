using Microsoft.EntityFrameworkCore;

namespace GerenciarCliente
{
    public class Conexao : DbContext
    {
        public Conexao(DbContextOptions<Conexao> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }


        //Mapeando Atributos de Cliente
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Cliente>()
                .HasKey(c => c.Email);

            modelBuilder.Entity<Cliente>()
                .Property(c => c.Nome).IsRequired().HasMaxLength(250);

            modelBuilder.Entity<Cliente>()
                .Property(c => c.CPF).IsRequired().HasMaxLength(11);

            modelBuilder.Entity<Cliente>()
                .Property(c => c.Senha).IsRequired().HasMaxLength(20);

            modelBuilder.Entity<Cliente>()
                .Property(c => c.DataNascimento).IsRequired().HasMaxLength(9);

            base.OnModelCreating(modelBuilder);
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Data Source = localhost; Persist Security Info = True; User ID = padrao; Password = 123456;TrustServerCertificate=True;");

        }
    
    }
}
