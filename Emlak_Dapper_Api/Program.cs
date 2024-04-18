using Emlak_Dapper_Api.Depo.AnaSayfaHizmetDeposu;
using Emlak_Dapper_Api.Depo.BizKimizDeposu;
using Emlak_Dapper_Api.Depo.BizKimizHizmetDeposu;
using Emlak_Dapper_Api.Depo.IletisimDeposu;
using Emlak_Dapper_Api.Depo.IstatistikDeposu;
using Emlak_Dapper_Api.Depo.KategoriDeposu;
using Emlak_Dapper_Api.Depo.PersonelDeposu;
using Emlak_Dapper_Api.Depo.PopülerLokasyonDeposu;
using Emlak_Dapper_Api.Depo.ReferansDeposu;
using Emlak_Dapper_Api.Depo.UrunDeposu;
using Emlak_Dapper_Api.Depo.YapýlacaklarDeposu;
using Emlak_Dapper_Api.Hubs;
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
builder.Services.AddTransient<IReferansDepo, ReferansDepo>();
builder.Services.AddTransient<IPersonelDepo, PersonelDepo>();
builder.Services.AddTransient<IIstatistikDepo, IstatistikDepo>();
builder.Services.AddTransient<IIletisimDepo, IletisimDepo>();
builder.Services.AddTransient<IYapýlacaklarDepo, YapýlacaklarDepo>();

//signalR///////////////////////////////////////
builder.Services.AddCors(opt=>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed((host) => true)
        .AllowCredentials();
    });
});
builder.Services.AddHttpClient();

builder.Services.AddSignalR();
///////////////////////////////////////////


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
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<SignalRHub>("/signalrhub");
//localhost:1234/swagger/kategori/index  kullanmak yerine localhost:1234/signalrhub 

app.Run();
