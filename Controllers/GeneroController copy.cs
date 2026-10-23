using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using PeliculasAPI.Entidades;

namespace PeliculasAPI.Controllers
{
    [Route("api/GenerosCopy")]
    [ApiController]
    public class GeneroControllerCopy: ControllerBase
    {

        private readonly IRepositorio repositorio;
        private readonly ServicioTransient transient1;
        private readonly ServicioTransient transient2;
        private readonly ServicioScoped scoped1;
        private readonly ServicioScoped scoped2;
        private readonly ServicioSingleton singleton1;
        private readonly IOutputCacheStore outputCacheStore;
        private readonly IConfiguration configuration;
        private const string cacheTag = "generos";
        //comments
        
        public GeneroControllerCopy(IRepositorio repositorio, ServicioTransient transient1, ServicioTransient transient2, ServicioScoped scoped1,ServicioScoped scoped2, ServicioSingleton singleton1, IOutputCacheStore outputCacheStore, IConfiguration configuration)
        {
            this.repositorio = repositorio;
            this.transient1 = transient1;
            this.transient2 = transient2;
            this.scoped1 = scoped1;
            this.scoped2 = scoped2;
            this.singleton1 = singleton1;
            this.outputCacheStore = outputCacheStore;
            this.configuration = configuration;
        }

        [HttpGet("ejemplo-proveedor-configuracion")]
        public string GetEjemploProveedorConfiguracion()
        {
            return configuration.GetValue<string>("CadenaDeConexion")!;
        }

        [HttpGet("servicios-tiempo-de-vida")]
        public IActionResult GetServicioTiempoDeVida()
        {
            return Ok(new
            {
                Transients = new {transient1 = transient1.ObtenerId, transient2.ObtenerId },
                Scopeds= new {scoped1 = scoped1.ObtenerId, scoped2 = scoped2.ObtenerId},
                Singleton = singleton1.ObtenerId
            });
        }


        [HttpGet()] // api/generos
        [HttpGet("listado")]
        [HttpGet("/listado-generos")]
        [OutputCache(Tags = [cacheTag])]
        public List<Genero> Get()
        {
            var generos = repositorio.ObtenerTodosLosGeneros();
            return generos;
        }

        [HttpGet("{id:int}")]// api/generos/500
        [OutputCache(Tags = [cacheTag])]
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
        public async Task<IActionResult> Post( [FromBody] Genero genero)
        {
            var yaExisteUnGeneroConDichoNombre = repositorio.Existe(genero.Nombre);

            if (yaExisteUnGeneroConDichoNombre)
            {
                return BadRequest($"Ya existe un genero con el nombre {genero.Nombre}");
            }

            repositorio.Crear(genero);
            await outputCacheStore.EvictByTagAsync(cacheTag, default);

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


