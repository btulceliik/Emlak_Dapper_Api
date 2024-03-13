using Dapper;
using Emlak_Dapper_Api.Dtos.AnaSayfaHizmetDtos;
using Emlak_Dapper_Api.Models.DapperContext;

namespace Emlak_Dapper_Api.Depo.AnaSayfaHizmetDeposu
{
    public class AnaSayfaHizmetDepo : IAnaSayfaHizmetDepo
    {
        private readonly Context _context;
        public AnaSayfaHizmetDepo(Context context)
        {
            _context = context;
        }

        //  Hizmet tablomdaki verileri çekmek için sorgum
        public async Task<List<AnaSayfaHizmetSonucDto>> GetAllAnaSayfaHizmetAsync()
        {
            string query = "Select * From Hizmet";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<AnaSayfaHizmetSonucDto>(query);
                return values.ToList();
            }
        }

        public void AnaSayfaHizmetGuncelle(AnaSayfaHizmetGuncelleDto hizmetguncelle)
        {
            throw new NotImplementedException();
        }

        public void AnaSayfaHizmetOlustur(AnaSayfaHizmetOlusturDto hizmetolustur)
        {
            throw new NotImplementedException();
        }

        public void AnaSayfaHizmetSil(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AnaSayfaHizmetGetirDto> AnaSayfaHizmetGetir(int id)
        {
            throw new NotImplementedException();
        }
    }
}
