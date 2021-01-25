using MerchandiseManager.Application.Contexts.Products.Queries.GetProductsByStorageId;
using MerchandiseManager.Application.Contexts.Warehouses.Commands.ReplenishStorage;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MerchandiseManager.Api.Controllers
{
	[Route("api/storage-products")]
	public class StorageProductsController : BaseController
	{
		[HttpGet("{storageId}")]
		public async Task<IActionResult> GetAllByStorageId([FromQuery] GetProductsByStorageIdQuery request)
			=> Ok(await Mediator.Send(request));

		[HttpPost]
		public async Task<IActionResult> Replenish([FromBody] ReplenishStorageCommand request)
			=> Ok(await Mediator.Send(request));

		//public async
	}
}
