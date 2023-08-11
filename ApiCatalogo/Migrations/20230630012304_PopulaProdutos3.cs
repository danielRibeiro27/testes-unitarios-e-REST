using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCatalogo.Migrations
{
    /// <inheritdoc />
    public partial class PopulaProdutos3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO PRODUTOS (NOME, DESCRICAO, ImagemUrl, PRECO, ESTOQUE, DATACADASTRO, CATEGORIAID) VALUES ('SUCO DE LARANJA 1L', 'SUCO GOSTOSO DE LARANJA VERDE', 'SUCOLARANJA.JPG', 18.70, 100, NOW(), 1)");
            mb.Sql("INSERT INTO PRODUTOS (NOME, DESCRICAO, ImagemUrl, PRECO, ESTOQUE, DATACADASTRO, CATEGORIAID) VALUES ('COCA-COLA 2L', 'REFRIGERANTE PRA RICO', 'COCACOLA.JPG', 39.90, 120, NOW(), 1)");
            mb.Sql("INSERT INTO PRODUTOS (NOME, DESCRICAO, ImagemUrl, PRECO, ESTOQUE, DATACADASTRO, CATEGORIAID) VALUES ('DELICIUS DIVINO', 'PÃO DE BRIOCHE, HAMBURGER ARTESANAL 150G, PICLES, CEBOLA ROXA, ALFACE AMERICANO CROCANTE, MOLHO AGRIDOCE PIMENTA C/ ABACAXI', 'DELICIUSDIVINO.JPG', 39.90, 2, NOW(), 2)");

            mb.Sql("INSERT INTO PRODUTOS (NOME, DESCRICAO, ImagemUrl, PRECO, ESTOQUE, DATACADASTRO, CATEGORIAID) VALUES ('PUDIM', 'PUDIM', 'PUDIM.JPG', 9.90, 35, NOW(), 3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM PRODUTOS");
        }
    }
}
