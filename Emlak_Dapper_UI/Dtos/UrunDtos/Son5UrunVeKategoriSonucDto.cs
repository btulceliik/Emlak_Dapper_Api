namespace Emlak_Dapper_UI.Dtos.UrunDtos
{
    public class Son5UrunVeKategoriSonucDto
    {
        public int UrunID { get; set; }
        public string Baslik { get; set; }
        public decimal Fiyat { get; set; }
        public string Sehir { get; set; }
        public string Ilce { get; set; }
        public int UrunKategori { get; set; }
        public string KategoriIsim { get; set; }
        public DateTime IlanTarihi { get; set; }

    }
}

