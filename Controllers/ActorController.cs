using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace PeliculasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IOutputCacheStore outputCacheStore;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private const string cacheTag = "actores";

        public ActorController(IOutputCacheStore outputCacheStore, ApplicationDbContext dbContext, IMapper mapper)
        {

            this.outputCacheStore = outputCacheStore;
            this.context = dbContext;
            this.mapper = mapper;
        }
    }
}
