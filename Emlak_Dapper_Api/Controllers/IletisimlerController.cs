using Emlak_Dapper_Api.Depo.IletisimDeposu;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Emlak_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IletisimlerController : ControllerBase
    {
        private readonly IIletisimDepo _iletisimDepo; // KategoriDepo bağımlılığı
        public IletisimlerController(IIletisimDepo iletisimDepo)
        {
            _iletisimDepo = iletisimDepo; // Dependency Injection ile gelen kategori depo atanır
        }

        // Tüm kategorileri getiren endpoint
        [HttpGet("Son4Iletisim")]
        public async Task<IActionResult> Son4Iletisim()
        {
            var values = await _iletisimDepo.Son4Iletisim();
            return Ok(values);
        }

    }
}
