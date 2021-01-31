using MerchandiseManager.Application.Contexts.StorageProducts.Commands.DeleteStorageProduct;
using MerchandiseManager.Application.Contexts.StorageProducts.Queries.GetUserProductsByStorageId;
using MerchandiseManager.Application.Contexts.Warehouses.Commands.ReplenishStorage;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MerchandiseManager.Api.Controllers
{
	[Route("api/storages/{storageId}/products")]
	public class StorageProductsController : BaseController
	{
		[HttpGet]
		public async Task<IActionResult> GetAllByStorageId([FromQuery] GetUserProductsByStorageIdQuery request)
			=> Ok(await Mediator.Send(request));

		[HttpPost]
		public async Task<IActionResult> Replenish([FromRoute]Guid storageId, [FromBody] ReplenishWarehouseCommand request)
		{
			request.StorageId = storageId;
			return Ok(await Mediator.Send(request));
		}

		[HttpDelete("{productId}")]
		public async Task<IActionResult> Delete([FromRoute] DeleteStorageProductCommand request)
			=> Ok(await Mediator.Send(request));
	}
}
