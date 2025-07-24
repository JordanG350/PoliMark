using maasapp.core.ConnectionSwagger;
using maasapp.infrastructure.Data;
using maasapp.infrastructure.Data.models;
using maasapp.infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace maasapp.Controllers
{
    [ApiController]
    // ruta de donde esta el metodo que se llama, en este caso api
    // [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        // se llama la interface en _db 
        private readonly IconnectionPostgresql _db;
        private readonly IConfiguration _config;

        // constructor igualado a la variable traida de la interface
        public LoginController(IconnectionPostgresql connectionpostgesql, IConfiguration configuration)
        {
            _db = connectionpostgesql;
            _config = configuration;
        }

        //ActionResult Retorna un evento
        //Metodo de autenticacion
        [HttpPost]
        [Route("GetToken")]
        public async Task<ActionResult> GetToken(TokenModel data)
        {
            try
            {
                //Crear metodo de verificacion credenciales ---> crear tabla en base de datos de credenciales.
                string jwtToken = GenerateToken(data);
                return Ok(new {Token = jwtToken });
            }
            catch (Exception ex)
            {
                return BadRequest("Algo fallo!" + ex.ToString());
            }
        }

        private string GenerateToken(TokenModel data) 
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, data.user),
                new Claim(ClaimTypes.SerialNumber, data.password)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: creds);

            string token = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return token;
        }
    }
}