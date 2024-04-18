
using Emlak_Dapper_Api.Depo.YapılacaklarDeposu;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Emlak_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YapılacaklarController : ControllerBase
    {
        private readonly IYapılacaklarDepo _yapılacaklarDepo;
        public YapılacaklarController(IYapılacaklarDepo yapılacaklarDepo)
        {
            _yapılacaklarDepo = yapılacaklarDepo;
        }

        [HttpGet]
        public async Task<IActionResult> YapılacaklarListe()
        {
            var values = await _yapılacaklarDepo.GetAllYapılacaklarAsync();
            return Ok(values);
        }
    }
}