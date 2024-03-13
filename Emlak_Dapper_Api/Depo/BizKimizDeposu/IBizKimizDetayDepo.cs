using Emlak_Dapper_Api.Dtos.BizKimizDetayDtos;

namespace Emlak_Dapper_Api.Depo.BizKimizDeposu
{
    public interface IBizKimizDetayDepo
    {
        Task<List<BizKimizDetaySonucDto>> GetAllBizKimizDetayAsync();

        void BizKimizDetayOlustur(BizKimizDetayOlusturDto bizKimizDetayOlusturDto);

        void BizKimizDetaySil(int id);
        void BizKimizDetayGuncelle(BizKimizDetayGuncelleDto bizKimizDetayGuncelleDto);
        Task<BizKimizDetayIDGetirDto> BizKimizDetayGetir (int id);

    }
}
