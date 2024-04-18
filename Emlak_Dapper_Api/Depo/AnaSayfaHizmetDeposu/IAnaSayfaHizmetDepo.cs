using Emlak_Dapper_Api.Dtos.AnaSayfaHizmetDtos;

namespace Emlak_Dapper_Api.Depo.AnaSayfaHizmetDeposu
{
    public interface IAnaSayfaHizmetDepo
    {
        Task<List<AnaSayfaHizmetSonucDto>> GetAllAnaSayfaHizmetAsync();
        void AnaSayfaHizmetOlustur(AnaSayfaHizmetOlusturDto hizmetOlusturDto);
        void AnaSayfaHizmetSil(int id);
        void AnaSayfaHizmetGuncelle(AnaSayfaHizmetGuncelleDto hizmetGuncelleDto);
        Task<AnaSayfaHizmetGetirDto> AnaSayfaHizmetGetir(int id);
    }
}
