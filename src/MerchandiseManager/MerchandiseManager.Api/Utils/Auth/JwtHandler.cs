using MerchandiseManager.Application.Interfaces.Authentication;
using MerchandiseManager.Application.Models.Config;
using MerchandiseManager.Core.Constants;
using MerchandiseManager.Core.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseManager.Api.Utils.Auth
{
	public class JwtHandler : IJwtHandler
	{
		private readonly AppSettings _appSettings;

		public JwtHandler(IOptions<AppSettings> appSettings)
		{
			_appSettings = appSettings.Value;
		}

		public string GenerateJwt(User user, Guid StoreId)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(_appSettings.JwtSettings.Secret);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
					new Claim(ClaimTypes.Name, user.GetFullName()),
					new Claim(CommonConstants.StoreIdClaimType, StoreId.ToString())
				}),
				Expires = DateTime.UtcNow.AddMinutes(_appSettings.JwtSettings.ExpirationMinutes),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);

			return tokenHandler.WriteToken(token);
		}
	}
}
