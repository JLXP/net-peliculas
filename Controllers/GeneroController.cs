using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using PeliculasAPI.Entidades;

namespace PeliculasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController: ControllerBase
    {

        private readonly IRepositorio repositorio;
        
        public GeneroController(IRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpGet()] // api/generos
        [HttpGet("listado")]
        [HttpGet("/listado-generos")]
        [OutputCache]
        public List<Genero> Get()
        {
            var generos = repositorio.ObtenerTodosLosGeneros();
            return generos;
        }

        [HttpGet("{id:int}")]// api/generos/500
        [OutputCache]
        public async Task<ActionResult<Genero>> Get(int id)
        {
            var repositorio = new RepositorioEnMemoria();
            var genero = await repositorio.ObtenerPorId(id);

            if(genero is null)
            {
                return NotFound();
            }

            return genero;
        }

         [HttpGet("{nombre}")]// api/generos/500
        public async Task<ActionResult<Genero?>> Get(string nombre = "Roberto")
        {
            var genero = await repositorio.ObtenerPorId(1);
            return genero;
        }


        [HttpPost()]
        public IActionResult Post( [FromBody] Genero genero)
        {
            var yaExisteUnGeneroConDichoNombre = repositorio.Existe(genero.Nombre);

            if (yaExisteUnGeneroConDichoNombre)
            {
                return BadRequest($"Ya existe un genero con el nombre {genero.Nombre}");
            }

            return Ok();
        }

        [HttpPut]
        public void Put()
        {

        }

        [HttpDelete]
        public void Delete()
        {

        }
    }
}


