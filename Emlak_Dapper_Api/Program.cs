using Emlak_Dapper_Api.Depo.AnaSayfaHizmetDeposu;
using Emlak_Dapper_Api.Depo.BizKimizDeposu;
using Emlak_Dapper_Api.Depo.HizmetDeposu;
using Emlak_Dapper_Api.Depo.KategoriDeposu;
using Emlak_Dapper_Api.Depo.PopülerLokasyonDeposu;
using Emlak_Dapper_Api.Depo.UrunDeposu;
using Emlak_Dapper_Api.Models.DapperContext;

var builder = WebApplication.CreateBuilder(args);

// Hizmetleri ekle.
builder.Services.AddTransient<Context>();
builder.Services.AddTransient<IKategoriDepo, KategoriDepo>();
builder.Services.AddTransient<IUrunDepo, UrunDepo>();
builder.Services.AddTransient<IBizKimizDetayDepo, BizKimizDetayDepo>();
builder.Services.AddTransient<IBizKimizHizmetDepo, BizKimizHizmetDepo>();
builder.Services.AddTransient<IAnaSayfaHizmetDepo, AnaSayfaHizmetDepo>();
builder.Services.AddTransient<IPopülerLokasyonDepo,PopülerLokasyonDepo>();





builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
