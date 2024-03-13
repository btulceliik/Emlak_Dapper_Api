namespace Emlak_Dapper_Api.Dtos.ReferansDtos
{
    public class ReferansSonucDto
    {
        public int ReferansID { get; set; }
        public string IsimSoyIsim { get; set; }
        public string Baslik {  get; set; }
        public string Yorum { get; set; }   
        public bool Durum { get; set; }
    }
}
