using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeliculasAPI.DTOs;
using PeliculasAPI.Utilidades;
using System.Linq.Expressions;

namespace PeliculasAPI.Controllers
{
    public class CustomBaseController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public CustomBaseController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        protected async Task<List<TDTO>> Get<TEntidad, TDTO>(PaginacionDTO paginacion,
            Expression<Func<TEntidad, object>> ordenarPor) where TEntidad: class
        {
            var queryable = context.Set<TEntidad>().AsQueryable();
            await HttpContext.InsertarParametrosPaginacionEnCabecera(queryable);
            return await queryable
                .OrderBy(ordenarPor)
                .Paginar(paginacion)
                .ProjectTo<TDTO>(mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
