namespace Emlak_Dapper_Api.Dtos.IletisimDtos
{
    public class IletisimSonucDto

    {
        public int IletisimID { get; set; }
        public string Isim { get; set; }
        public string Konu { get; set; }
        public string Email { get; set; }
        public string Mesaj { get; set; }
        public DateTime GonderimTarihi { get; set; }
    }
}
