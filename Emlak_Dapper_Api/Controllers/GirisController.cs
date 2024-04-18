using Dapper;
using Emlak_Dapper_Api.Dtos.GirisDtos;
using Emlak_Dapper_Api.Models.DapperContext;
using Emlak_Dapper_Api.Tools;
using Microsoft.AspNetCore.Mvc;

namespace Emlak_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GirisController : ControllerBase
    {
        private readonly Context _context;
        public GirisController(Context context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> GirisYap(GirisOlusturDto girisDto)
        {
            string query = "Select * From Kullanici Where KullaniciIsim=@kullaniciIsim and Sifre=@sifre";
            string query2 = "Select KullaniciID From Kullanici Where KullaniciIsim=@kullaniciIsim and Sifre=@sifre";
            var parameters = new DynamicParameters();
            parameters.Add("@kullaniciIsim", girisDto.KullaniciIsim);
            parameters.Add("@sifre", girisDto.Sifre);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GirisOlusturDto>(query, parameters);
                var values2 = await connection.QueryFirstOrDefaultAsync<KullaniciIDGetiDto>(query, parameters);

                if (values != null)
                {
                    KullaniciKontrol model = new KullaniciKontrol();
                    model.KullaniciIsim = values.KullaniciIsim;
                    model.ID= values2.KullaniciID;
                    var token = JwtTokenJenerator.TokenUret(model);
                    return Ok(token);
                }
                else
                {
                    return Ok("Başarısız");
                }

            }
        }
    }
}