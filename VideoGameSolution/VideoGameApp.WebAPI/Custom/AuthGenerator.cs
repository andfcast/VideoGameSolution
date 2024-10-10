using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VideoGameApp.Domain.DTO;

namespace VideoGameApp.WebAPI.Custom
{
    public class AuthGenerator
    {
        private readonly IConfiguration _configuration;

        public AuthGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerarJwt(UsuarioDto objUsuario) {
            var userClaims = new[] {
                new Claim(ClaimTypes.NameIdentifier, objUsuario.Id.ToString()),
                new Claim(ClaimTypes.Name, objUsuario.NombreUsuario.ToString()),
                new Claim(ClaimTypes.Email, objUsuario.Email.ToString()),
            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var jwtConfig = new JwtSecurityToken(
                    claims: userClaims,
                    expires:DateTime.Now.AddMinutes(60),
                    signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(jwtConfig);
        }
    }
}
