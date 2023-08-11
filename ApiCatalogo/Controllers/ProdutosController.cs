using ApiCatalogo.Context;
using ApiCatalogo.Migrations;
using ApiCatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _ctx;

        public ProdutosController(AppDbContext? ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        //Pq IEnumerable e não LIST ?
        //R: 1º trabalha por demanda 2º não precisa ter toda coleção na memória 3º é mais otimizado
        //ActionResult permite retornar o código de status NotFound OU a coleção IEnumerable
        //NotFound herda (neto) do ActionResult
        public async Task<ActionResult<IEnumerable<Produto>>> GetAsync()
        {
            var produtos = await _ctx.Produtos.AsNoTracking().ToListAsync();
            if (produtos is null)
                return NotFound("Produtos não encontrados..."); //404

            return produtos;
        }

        [HttpGet("{id:int:min(1)}", Name = "ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            var produto = _ctx.Produtos.FirstOrDefault(x => x.ProdutoId == id);
            if (produto is null)
                return NotFound("Produto não encontrado...");

            return produto;
        }

        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            if (produto is null)
                BadRequest();

            _ctx.Produtos.Add(produto); //adiciona na memória
            _ctx.SaveChanges(); //persiste na tabela

            //retorna o 201 CREATED e redireciona para o endpoint 
            return new CreatedAtRouteResult("ObterProduto", new { id = produto.ProdutoId, produto });
        }

        [HttpPut("{id:int}")]
        //PUT: Atualiza completamente o produto, sendo necessário enviar todos os campos
        //PATCH: Atualiza somente os campos alterados
        public ActionResult Put(int id, Produto produto)
        {
            if (id != produto.ProdutoId)
                return BadRequest();

            _ctx.Entry(produto).State = EntityState.Modified; //diz que a entidade precisa ser persistida
            _ctx.SaveChanges();

            return Ok(produto); //200 OK
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var produto = _ctx.Produtos.FirstOrDefault(x => x.ProdutoId == id);
            //var produto = _ctx.Produtos.Find(id); //vantagem do Find é que ele procura primeiro na memória

            if (produto is null)
                return NotFound("Produto não localizado...");

            _ctx.Produtos.Remove(produto);
            _ctx.SaveChanges();
            return Ok();
        }
    }
}
