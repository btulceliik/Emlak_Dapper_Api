using System.Security.Claims;

namespace Emlak_Dapper_UI.Services
{
    public class GirisServis:IGirisServis
    {
        private readonly IHttpContextAccessor _contextAccesor;
        public GirisServis(IHttpContextAccessor contextAccesor)
        {
            _contextAccesor = contextAccesor;
        }

        public string GetKullaniciID => _contextAccesor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
    }
}
