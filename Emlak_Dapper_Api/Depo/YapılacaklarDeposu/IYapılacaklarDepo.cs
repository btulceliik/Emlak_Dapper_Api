
using Emlak_Dapper_Api.Dtos.YapılacaklarDtos;

namespace Emlak_Dapper_Api.Depo.YapılacaklarDeposu
{
    public interface IYapılacaklarDepo
    {
 
        Task<List<YapılacaklarSonucDto>> GetAllYapılacaklarAsync();
        void YaplacaklarOlustur(YapılacaklarOlusturDto yapilacaklarDto);
        void YapılacaklarSil(int id);
        void YapılacaklarGuncelle(YapılacaklarGuncelleDto yapilacaklarDto);
        Task<YapılacaklarIDGetirDto> YapılacaklarIDGetir(int id);
    }
}
