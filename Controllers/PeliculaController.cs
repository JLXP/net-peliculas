using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace PeliculasAPI.Controllers
{
    [Route("api/peliculas")]
    [ApiController]
    public class PeliculaController: CustomBaseController
    {
        private static string cacheTag = "peliculas";
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IOutputCacheStore outputCacheStore;

        public PeliculaController(ApplicationDbContext context, IMapper mapper, IOutputCacheStore outputCacheStore): base(context, mapper, outputCacheStore, cacheTag)
        {
            this.context = context;
            this.mapper = mapper;
            this.outputCacheStore = outputCacheStore;
        }
    }
}
