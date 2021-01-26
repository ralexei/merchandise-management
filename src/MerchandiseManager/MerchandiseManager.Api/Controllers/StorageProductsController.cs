using MerchandiseManager.Application.Contexts.Products.Queries.GetProductsByStorageId;
using MerchandiseManager.Application.Contexts.StorageProducts.Commands.DeleteStorageProduct;
using MerchandiseManager.Application.Contexts.Warehouses.Commands.ReplenishStorage;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MerchandiseManager.Api.Controllers
{
	[Route("api/storages/{storageId}/products")]
	public class StorageProductsController : BaseController
	{
		[HttpGet]
		public async Task<IActionResult> GetAllByStorageId([FromQuery] GetProductsByStorageIdQuery request)
			=> Ok(await Mediator.Send(request));

		[HttpPost]
		public async Task<IActionResult> Replenish([FromRoute]Guid storageId, [FromBody] ReplenishStorageCommand request)
		{
			request.StorageId = storageId;
			return Ok(await Mediator.Send(request));
		}


		[HttpDelete("{productId}")]
		public async Task<IActionResult> Delete([FromRoute] DeleteStorageProductCommand request)
			=> Ok(await Mediator.Send(request));
	}
}
