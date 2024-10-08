using EmprestimoLivros.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmprestimoLivros.Infra.Data.Context {

    public class EmprestimoDbContext : DbContext {
        public EmprestimoDbContext(DbContextOptions<EmprestimoDbContext> options) 
        : base(options)  {}

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Livro> Livros { get; set; }

        public DbSet<Emprestimo> Emprestimos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

             
        }
    }
}