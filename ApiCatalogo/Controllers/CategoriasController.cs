using ApiCatalogo.Context;
using ApiCatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly AppDbContext _ctx;

        public CategoriasController(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet("produtos")]
        public ActionResult<IEnumerable<Categoria>> GetCategoriasProdutos()
        {
            return _ctx.Categorias.Include(x => x.Produtos).Where(c => c.CategoriaId <= 5).ToList();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            try
            {
                return _ctx.Categorias.AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                //return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratra sua solicitação.");
                return BadRequest();
            }
        }

        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public ActionResult<Categoria> Get(int id)
        {
            try
            {
                var categoria = _ctx.Categorias.FirstOrDefault(x => x.CategoriaId == id);
                if (categoria is null)
                    return NotFound($"Categoria com id={id} não encontrada.");

                return categoria;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratra sua solicitação.");
            }

        }

        [HttpPost]
        public ActionResult Post(Categoria categoria)
        {
            if (categoria is null)
            {
                return BadRequest("Dados inválidos.");
            }

            _ctx.Categorias.Add(categoria);
            _ctx.SaveChanges();

            return new CreatedAtRouteResult("ObterCategoria", new { id = categoria.CategoriaId, categoria });
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Categoria categoria)
        {
            if (id != categoria.CategoriaId)
                return BadRequest("Dados inválidos.");

            _ctx.Entry(categoria).State = EntityState.Modified;
            _ctx.SaveChanges();
            return Ok(categoria);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Categoria> Delete(int id)
        {
            var categoria = _ctx.Categorias.FirstOrDefault(x => x.CategoriaId == id);
            if (categoria is null)
                return NotFound($"Categoria com id={id} não encontrada.");

            _ctx.Categorias.Remove(categoria);
            _ctx.SaveChanges();
            return Ok(categoria);
        }
    }
}
