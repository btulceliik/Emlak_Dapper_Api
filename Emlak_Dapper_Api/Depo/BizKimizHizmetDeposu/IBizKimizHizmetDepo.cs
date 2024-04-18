using Emlak_Dapper_Api.Dtos.BizKimizHizmetDtos;

namespace Emlak_Dapper_Api.Depo.BizKimizHizmetDeposu
{
    public interface IBizKimizHizmetDepo
    {
        Task<List<BizKimizHizmetSonucDto>> GetAllHizmetAsync();

        void HizmetOlustur(BizKimizHizmetOlusturDto hizmetOlusturDto);

        void HizmetSil(int id);
        void HizmetGuncelle(BizKimizHizmetGuncelleDto hizmetGuncelleDto);
        Task<BizKimizHizmetIDGetirDto> HizmetGetir(int id);
    }
}
