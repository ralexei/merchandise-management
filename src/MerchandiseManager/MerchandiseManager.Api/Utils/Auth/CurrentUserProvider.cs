using MerchandiseManager.Application.Interfaces.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Security.Claims;

namespace MerchandiseManager.Api.Utils.Auth
{
	public class CurrentUserProvider : ICurrentUser
	{
		public Guid Id { get; }
		public Guid StoreId { get; }

		public CurrentUserProvider(IHttpContextAccessor httpContextAccessor)
		{
			var idClaim = httpContextAccessor?
				.HttpContext?
				.User?
				.Claims?
				.FirstOrDefault(f => f.Type == ClaimTypes.NameIdentifier)?.Value;

			Id = string.IsNullOrEmpty(idClaim) ? default : new Guid(idClaim);

			//Id = new Guid() ?? default;

			var storeId = httpContextAccessor?
				.HttpContext?
				.User?
				.Claims?
				.FirstOrDefault(f => f.Type == "StoreId")?.Value;

			StoreId = string.IsNullOrEmpty(storeId) ? default : new Guid(storeId);
		}
	}
}
