using MerchandiseManager.Application.Contexts.Products.Queries.GetStoreProductsByUser;
using MerchandiseManager.Application.Contexts.Stores.Commands.ReplenishStore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MerchandiseManager.Api.Controllers
{
	[Route("api/stores/{storeId}/products")]
	public class StoreProductsController : BaseController
	{
		[HttpGet]
		public async Task<IActionResult> GetUserStoreProducts([FromQuery] GetStoreProductsByUserQuery request)
			=> Ok(await Mediator.Send(request));

		[HttpPost]
		public async Task<IActionResult> Replenish([FromRoute] Guid storeId, [FromBody] ReplenishStoreCommand request)
		{
			request.StoreId = storeId;

			await Mediator.Send(request);

			return NoContent();
		}
	}
}
