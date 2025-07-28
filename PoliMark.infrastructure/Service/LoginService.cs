using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using polimark.infrastructure.Data;
using polimark.infrastructure.Data.models;
using PoliMark.infraestructure.Data.models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PoliMark.infraestructure.Service
{
    public class LoginService : ILoginService
    {
        private readonly IconnectionSql _db;
        private readonly IConfiguration _config;

        public LoginService(IconnectionSql connectionSql, IConfiguration configuration)
        {
            _db = connectionSql;
            _config = configuration;
        }

        public async Task<ResponseModelUser> ValidateUser(string user, string password)
        {
            var usuario = new ResponseModelUser();
            string token = "";
            var existUser = await _db.getUsers(user, password);
            if (existUser != null)
            {
                token = GenerateToken(existUser);
                usuario.id = existUser.id;
                usuario.name = existUser.name;
                usuario.user = existUser.user;
                usuario.token = token;
            }
            return usuario;
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
