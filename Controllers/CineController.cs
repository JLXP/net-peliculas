using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using PeliculasAPI.DTOs;
using PeliculasAPI.Entidades;

namespace PeliculasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CineController : CustomBaseController
    {
        private const string cacheTag = "cines";
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IOutputCacheStore outputCacheStore;

        public CineController(ApplicationDbContext context, IMapper mapper, IOutputCacheStore outputCacheStore): base(context, mapper, outputCacheStore, cacheTag)
        {
            this.context = context;
            this.mapper = mapper;
            this.outputCacheStore = outputCacheStore;
        }

        [HttpGet]
        [OutputCache(Tags = [cacheTag])]
        public async Task<List<CineDTO>> Get([FromQuery] PaginacionDTO paginacion)
        {
            return await Get<Cine, CineDTO>(paginacion, ordenarPor: c => c.Nombre);
        }

        [HttpGet("{int:id}",  Name ="ObtenerPorId")]
        public async Task<ActionResult<CineDTO>> Get(int id)
        {
            return await Get<Cine, CineDTO>(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CineCreacionDTO cineCreacionDTO)
        {
            return await Post<CineCreacionDTO, Cine, CineDTO>(cineCreacionDTO, "ObtenerPorId");
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] CineCreacionDTO cineCreacionDTO)
        {
            return await Put<CineCreacionDTO, Cine>(id, cineCreacionDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete (int id)
        {
            return await Delete<Cine>(id);
        }
    }
}
