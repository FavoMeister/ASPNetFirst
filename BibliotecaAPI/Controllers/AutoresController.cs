using BibliotecaAPI.Datos;
using BibliotecaAPI.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Controllers
{
    [ApiController]
    [Route("api/autores")]
    public class AutoresController: ControllerBase
    {
        private readonly ApplicationDBContext context;
        public AutoresController(ApplicationDBContext context) {
            this.context = context;
        }
        [HttpGet]
        /*public string Get()
        {
            return "autores";
        }*/
        public async Task<IEnumerable<Autor>> Get()
        {
            /*return new List<Autor> {
                new Autor{ID = 1, Nombre = "Jhon"},
                new Autor{ID = 2, Nombre = "Abigail"}
            };*/
            return await context.Autores.ToListAsync();
        }

        [HttpGet("primero")]
        public async Task<Autor> GetPrimerAutor()
        {
            return await context.Autores.FirstAsync();
        }

        [HttpGet("{id:int}")] //difference between the other get
        public async Task<ActionResult<Autor>> Get(int id)
        {
            var autor = await context.Autores
                .Include(x => x.Libros)
                .FirstOrDefaultAsync(x => x.ID == id);

            if (autor is null)
            {
                return NotFound();
            }

            return autor;
        }

        [HttpGet("{nombre:alpha}")]
        public async Task<IEnumerable<Autor>> Get(string nombre)
        {
            return await context.Autores.Where(x => x.Nombre.Contains(nombre)).ToListAsync();
        }

        [HttpPost] //Action
        public async Task<ActionResult> Post(Autor autor)
        {
            context.Add(autor);
            await context.SaveChangesAsync(); //operator allows you to send the query and not wait until the answer
            return Ok();
        }

        [HttpPut("{id:int}")] // api/autores/id
        public async Task<ActionResult> Put(int id, Autor autor)
        {
            if (id != autor.ID)
            {
                return BadRequest("Los ids deben coincidir");
            }

            context.Update(autor);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var registrosBorrados = await context.Autores.Where(x => x.ID == id).ExecuteDeleteAsync();
            if (registrosBorrados == 0)
            {
                return NotFound();
            }

            return Ok();
        }

    }
}
