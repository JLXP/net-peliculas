using Microsoft.AspNetCore.Mvc;
using PeliculasAPI.Entidades;

namespace PeliculasAPI.Controllers
{
    [Route("api/[controller]")]
    public class GeneroController: ControllerBase
    {
        [HttpGet()] // api/generos
        [HttpGet("listado")]
        [HttpGet("/listado-generos")]
        public List<Genero> Get()
        {
            var repositorio = new RepositorioEnMemoria();
            var generos = repositorio.ObtenerTodosLosGeneros();
            return generos;
        }

        [HttpGet("{id:int}/{nombre?}")]// api/generos/500
        public ActionResult<Genero> Get(int id, string nombre = "Roberto")
        {
            var repositorio = new RepositorioEnMemoria();
            var genero = repositorio.ObtenerPorId(id);

            if(genero is null)
            {
                return NotFound();
            }

            return genero;
        }

         [HttpGet("{nombre}")]// api/generos/500
        public Genero? Get(string nombre = "Roberto")
        {
            var repositorio = new RepositorioEnMemoria();
            var genero = repositorio.ObtenerPorId(1);
            return genero;
        }


        [HttpPost]
        public void Post()
        {

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


