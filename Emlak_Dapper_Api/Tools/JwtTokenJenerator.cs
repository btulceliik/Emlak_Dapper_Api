using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Emlak_Dapper_Api.Tools
{
    public class JwtTokenJenerator
    {
        public static TokenYanit TokenUret(KullaniciKontrol model)
        {
           
            var claims = new List<Claim>();

           
            if (!string.IsNullOrWhiteSpace(model.Rol))
                claims.Add(new Claim(ClaimTypes.Role, model.Rol));

            claims.Add(new Claim(ClaimTypes.NameIdentifier, model.ID.ToString()));

            if (!string.IsNullOrWhiteSpace(model.KullaniciIsim))
                claims.Add(new Claim("KullaniciIsim", model.KullaniciIsim));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtToken.Anahtar));
            var signinCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expireDate = DateTime.UtcNow.AddDays(JwtToken.SonaErme);

            
            JwtSecurityToken token = new JwtSecurityToken(issuer: JwtToken.Dinlenecek, audience: JwtToken.Yayıncı, claims: claims,
                                                          notBefore: DateTime.UtcNow, expires: expireDate, signingCredentials: signinCredentials);

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

         
            return new TokenYanit(tokenHandler.WriteToken(token), expireDate);



























        }

    }
}
