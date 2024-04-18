using Emlak_Dapper_Api.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Emlak_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        [HttpPost]
        public IActionResult TokenOlustur(KullaniciKontrol model)
        {
            // Gelen kullanıcı bilgileriyle bir JWT oluşturuluyor
            var values = JwtTokenJenerator.TokenUret(model);
            return Ok(values);
            
        
        }
    }
}
