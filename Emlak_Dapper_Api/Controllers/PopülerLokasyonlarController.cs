using Emlak_Dapper_Api.Depo.PopülerLokasyonDeposu;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Emlak_Dapper_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PopülerLokasyonlarController : ControllerBase
	{
		private readonly IPopülerLokasyonDepo _popülerLokasyonDepo;

		public PopülerLokasyonlarController(IPopülerLokasyonDepo popülerLokasyonDepo)
		{
			this._popülerLokasyonDepo = popülerLokasyonDepo;
		}

		[HttpGet]
		public async Task<IActionResult> PopülerLokasyonListe()
		{
			var value= await _popülerLokasyonDepo.GetAllPopülerLokasyonAsync();
			return Ok(value);
		}
	}
}
