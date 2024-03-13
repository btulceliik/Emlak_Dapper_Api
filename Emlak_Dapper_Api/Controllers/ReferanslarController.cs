using Emlak_Dapper_Api.Depo.ReferansDeposu;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Emlak_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferanslarController : ControllerBase
    {
        private readonly IReferansDepo _referansDepo;

        public ReferanslarController(IReferansDepo referansDepo)
        {
            this._referansDepo = referansDepo;
        }

        [HttpGet]
        public async Task<IActionResult> ReferansListe()
        {
            var value = await _referansDepo.GetAllReferansAsync();
            return Ok(value);
        }
    }
}
