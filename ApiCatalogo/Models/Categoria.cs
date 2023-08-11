using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCatalogo.Models
{
    //Classe anêmica (só possui propriedades)
    [Table("Categorias")]
    public class Categoria
    {
        public Categoria()
        {
            Produtos = new List<Produto>();
        }


        public int CategoriaId { get; set; }

        public string? Nome { get; set; }

        public string? ImageUrl { get; set; }

        public ICollection<Produto>? Produtos { get; set; }
    }
}
