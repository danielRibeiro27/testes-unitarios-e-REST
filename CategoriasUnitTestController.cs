using ApiCatalogo.Context;
using ApiCatalogo.Controllers;
using ApiCatalogo.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace ApiCatalogoTests
{
    public class CategoriasUnitTestController
    {

        private AppDbContext ctx;

        public static DbContextOptions<AppDbContext> options { get; }

        public static string connectionString = "Server=localhost/DataBase=CatalogoDB;Uid=root;Pwd=test";

        //O construtor estático é chamado automaticamente antes que a instância seja criada
        static CategoriasUnitTestController()
        {
            options = new DbContextOptionsBuilder<AppDbContext>().UseMySql(connectionString,ServerVersion.AutoDetect(connectionString)).Options;
        }

        public CategoriasUnitTestController()
        {
            ctx = new AppDbContext(options);

            //Alimenta o banco de dados
            DBUnityTestsMockInitializer db = new DBUnityTestsMockInitializer();
            db.Seed(ctx);
        }

        //Teste Unitários
        [Fact]
        public void GetCategorias_Return_OkResult()
        {
            //Arrange
            var controller = new CategoriasController(ctx);

            //Act
            var data = controller.Get();

            //Assert
            Assert.IsType<List<Categoria>>(data.Value);
        }

    }
}
