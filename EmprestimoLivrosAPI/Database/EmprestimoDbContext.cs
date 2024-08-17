using EmprestimoLivrosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmprestimoLivrosAPI.Database {

    public class EmprestimoDbContext : DbContext {
        public EmprestimoDbContext(DbContextOptions<EmprestimoDbContext> options) 
        : base(options)  {}

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Livro> Livros { get; set; }

        public DbSet<Emprestimo> Emprestimos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

             modelBuilder.Entity<Cliente>()
                .HasMany(e => e.Emprestimo)
                .WithOne(e => e.Cliente)
                .HasForeignKey(e => e.ClienteId)
                .HasPrincipalKey(e => e.Id);

            modelBuilder.Entity<Livro>()
                .HasMany(e => e.Emprestimo)
                .WithOne(e => e.Livro)
                .HasForeignKey(e => e.LivroId)
                .HasPrincipalKey(e => e.Id);
        }
    }
}