using ApiCatalogo.Context;
using ApiCatalogo.Models;

namespace ApiCatalogoTests
{
    public class DBUnityTestsMockInitializer
    {
        public DBUnityTestsMockInitializer()
        {
            
        }

        public void Seed(AppDbContext context)
        {
            context.Categorias.Add
            (new Categoria { Nome = "Bebidas999", ImageUrl = "bebidas999.jpg" });

            context.Categorias.Add
            (new Categoria { Nome = "Sucos", ImageUrl = "sucos1.jpg" });

            context.Categorias.Add
            (new Categoria { Nome = "Doces", ImageUrl = "doces1.jpg" });

            context.Categorias.Add
            (new Categoria { Nome = "Salgados", ImageUrl = "Salgados1.jpg" });

            context.Categorias.Add
            (new Categoria { Nome = "Tortas", ImageUrl = "tortas1.jpg" });

            context.Categorias.Add
            (new Categoria { Nome = "Bolos", ImageUrl = "bolos1.jpg" });

            context.Categorias.Add
            (new Categoria { Nome = "Lanches", ImageUrl = "lanches1.jpg" });

            context.SaveChanges();
        }
    }
}
