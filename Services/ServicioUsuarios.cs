using Microsoft.AspNetCore.Identity;

namespace PeliculasAPI.Services
{
    public class ServicioUsuarios : IServicioUsuarios
    {
        private readonly IHttpContextAccessor httpContextAccesor;
        private readonly UserManager<IdentityUser> userManager;

        public ServicioUsuarios(IHttpContextAccessor httpContextAccesor, UserManager<IdentityUser> userManager)
        {
            this.httpContextAccesor = httpContextAccesor;
            this.userManager = userManager;
        }


        public async Task<string> ObtenerUsuarioId()
        {
            var email = httpContextAccesor.HttpContext!.User.Claims.FirstOrDefault(x => x.Type == "email")!.Value;
            var usuario = await userManager.FindByEmailAsync(email);
            return usuario!.Id;
        }
    }
}
