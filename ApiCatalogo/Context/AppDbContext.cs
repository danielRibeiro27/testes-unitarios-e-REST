using ApiCatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) //construtor da classe base
        {
        }

        public DbSet<Categoria>? Categorias { get; set; }
        public DbSet<Produto>? Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            //categoria
            mb.Entity<Categoria>().HasKey(x => x.CategoriaId);
            mb.Entity<Categoria>().Property(x => x.Nome).HasMaxLength(100).IsRequired();
            //mb.Entity<Categoria>().Property(x => x.Descricao).HasMaxLength(100).IsRequired();

            //produto
            mb.Entity<Produto>().HasKey(x => x.ProdutoId);
            mb.Entity<Produto>().Property(x => x.Nome).HasMaxLength(100).IsRequired();
            mb.Entity<Produto>().Property(x => x.Descricao).HasMaxLength(100);
            mb.Entity<Produto>().Property(x => x.Imagem).HasMaxLength(100);

            //relacionamento
            mb.Entity<Produto>().HasOne<Categoria>(x => x.Categoria).WithMany(x => x.Produtos).HasForeignKey(x => x.CategoriaId);
        }
    }
}
