using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Proyecto.Core.InterfacesServices;
using UESAN.Proyecto.Core.Utilidades;
using UESAN.Proyecto.Core.entities;
using System.Security.Claims;

namespace UESAN.proyecto.Infrastructure.Shared
{
	public class JWTFactory : IJWTFactory
	{
		public JWTSettings _settings { get; }
		public JWTFactory(IOptions<JWTSettings> settings)
		{
			_settings = settings.Value;
		}

		public string GenerateJWToken(Usuarios user)
		{
			var ssk = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey));
			var sc = new SigningCredentials(ssk, SecurityAlgorithms.HmacSha256);
			var header = new JwtHeader(sc);

			var claims = new[] {
				/*
					new Claim(ClaimTypes.Name, (user.Nombre + "" + user.LastName)),
					new Claim(ClaimTypes.GivenName, user.FirstName),
					new Claim(ClaimTypes.Email, user.Email),
					new Claim(ClaimTypes.DateOfBirth, user.DateOfBirth.ToString()),
					new Claim(ClaimTypes.Country, user.Country),
					new Claim(ClaimTypes.Role, user.Type == "A" ? "Admin": "User"),
					new Claim("UserId",user.Id.ToString()),

				*/
					new Claim(ClaimTypes.NameIdentifier, user.IdUsuario.ToString()),
					new Claim(ClaimTypes.Email, user.Correo),
					new Claim(ClaimTypes.Name, user.Nombre),
					new Claim("Area", user.Area),
					new Claim(ClaimTypes.Role, user.Tipo),
				};

			var payload = new JwtPayload(
							_settings.Issuer
							, _settings.Audience
							, claims
							, DateTime.UtcNow
							, DateTime.UtcNow.AddMinutes(_settings.DurationInMinutes));

			var token = new JwtSecurityToken(header, payload);
			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
