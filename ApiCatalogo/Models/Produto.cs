using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiCatalogo.Models
{
    //Classe anêmica (só possui propriedades)
    [Table("Produtos")]
    public class Produto
    {

        public int ProdutoId { get; set; }


        public string? Nome { get; set; }


        public string? Descricao { get; set; }


        public string? Imagem { get; set; }


        public decimal Preco { get; set; }

        public float Estoque { get; set; }
        public DateTime DataCadastro { get; set; }

        public int CategoriaId { get; set; }

        public Categoria? Categoria { get; set; }
    }
}
