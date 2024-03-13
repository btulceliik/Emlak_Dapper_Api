using Emlak_Dapper_Api.Depo.HizmetDeposu;
using Microsoft.AspNetCore.Mvc;

namespace Emlak_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BizKimizHizmetlerController : ControllerBase
    {
        private readonly IBizKimizHizmetDepo _hizmetDepo;

        public BizKimizHizmetlerController(IBizKimizHizmetDepo hizmetDepo)
        {
            _hizmetDepo = hizmetDepo;
        }
        [HttpGet] 
        public async Task<IActionResult> GetHizmetListe()
        {
            var value= await _hizmetDepo.GetAllHizmetAsync();
            return Ok(value);
        }
    }
}
