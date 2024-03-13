using Emlak_Dapper_Api.Dtos.AnaSayfaHizmetDtos;

namespace Emlak_Dapper_Api.Depo.AnaSayfaHizmetDeposu
{
    public interface IAnaSayfaHizmetDepo
    {
        Task<List<AnaSayfaHizmetSonucDto>> GetAllAnaSayfaHizmetAsync();
        void AnaSayfaHizmetOlustur(AnaSayfaHizmetOlusturDto hizmetolustur);
        void AnaSayfaHizmetSil(int id);
        void AnaSayfaHizmetGuncelle(AnaSayfaHizmetGuncelleDto hizmetguncelle);
        Task<AnaSayfaHizmetGetirDto> AnaSayfaHizmetGetir(int id);
    }
}
