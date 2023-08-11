using ApiCatalogo.Context;
using ApiCatalogo.Controllers;
using ApiCatalogo.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace ApiCatalogoTests
{
    public class CategoriasUnitTestController
    {

        private AppDbContext ctx;

        public static DbContextOptions<AppDbContext> options { get; }

        public static string connectionString = "Server=localhost;DataBase=catalogodb;Uid=root;Pwd=197527";

        //O construtor estático é chamado automaticamente antes que a instância seja criada
        static CategoriasUnitTestController()
        {
            options = new DbContextOptionsBuilder<AppDbContext>().UseMySql(connectionString,ServerVersion.AutoDetect(connectionString)).Options;
        }

        public CategoriasUnitTestController()
        {
            ctx = new AppDbContext(options);

            ////Alimenta o banco de dados
            //DBUnityTestsMockInitializer db = new DBUnityTestsMockInitializer();
            //db.Seed(ctx);
        }

        #region Testes Unitários


        //GET - GetAll - OkResult
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

        //GET - GetAll - BadRequest
        [Fact]
        public void GetCategorias_Return_BadRequestResult()
        {
            //Arrange
            var controller = new CategoriasController(ctx);

            //Act
            var data = controller.Get();

            //Assert
            Assert.IsType<BadRequestResult>(data.Result);
        }

        //GET - GetAll - MatchResult
        [Fact]
        public void GetCategorias_Return_MatchResult()
        {
            //Arrange
            var controller = new CategoriasController(ctx);

            //Act
            var data = controller.Get();

            //Assert
            Assert.IsType<List<Categoria>>(data.Value);

            //Atribui a lista de categorias a variavel Cat
            var cat = data.Value.Should().BeAssignableTo<List<Categoria>>().Subject;

            Assert.Equal("Bebidas", cat[0].Nome);
            Assert.Equal("bebidas.jpg", cat[0].ImageUrl);

            Assert.Equal("Sobremesas", cat[2].Nome);
            Assert.Equal("sobremesas.jpg", cat[2].ImageUrl);
        }


        //GET - GetById - OkResult
        [Fact]
        public void GetCategoriaById_Return_OkResult()
        {
            //Arrange
            var controller = new CategoriasController(ctx);
            var catId = 3;

            //Act
            var data = controller.Get(catId);

            //Assert
            Assert.IsType<Categoria>(data.Value);
        }

        //POST - CreatedResult
        [Fact]
        public void PostCategoria_Return_OkResult()
        {
            //Arrange
            var controller = new CategoriasController(ctx);
            Categoria cat = new Categoria() { Nome = "Teste Unit 01", ImageUrl = "testunit01.jpg" };

            //Act
            var data = controller.Post(cat);

            //Assert
            Assert.IsType<CreatedAtRouteResult>(data);
        }



        #endregion

    }
}
