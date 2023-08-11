using ApiCatalogo.Context;
using ApiCatalogo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCatalogoTests
{
    internal class DBUnityTestsMockInitializer
    {
        public DBUnityTestsMockInitializer()
        {
            
        }

        public void Seed(AppDbContext context)
        {
            context.Categorias.Add
            (new Categoria { CategoriaId = 999, Nome = "Bebidas999", ImageUrl = "bebidas999.jpg" });

            context.Categorias.Add
            (new Categoria { CategoriaId = 2, Nome = "Sucos", ImageUrl = "sucos1.jpg" });

            context.Categorias.Add
            (new Categoria { CategoriaId = 3, Nome = "Doces", ImageUrl = "doces1.jpg" });

            context.Categorias.Add
            (new Categoria { CategoriaId = 4, Nome = "Salgados", ImageUrl = "Salgados1.jpg" });

            context.Categorias.Add
            (new Categoria { CategoriaId = 5, Nome = "Tortas", ImageUrl = "tortas1.jpg" });

            context.Categorias.Add
            (new Categoria { CategoriaId = 6, Nome = "Bolos", ImageUrl = "bolos1.jpg" });

            context.Categorias.Add
            (new Categoria { CategoriaId = 7, Nome = "Lanches", ImageUrl = "lanches1.jpg" });

            context.SaveChanges();
        }
    }
}
