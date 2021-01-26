using MerchandiseManager.Application.Contexts.Stores.Commands.AddNewStore;
using MerchandiseManager.Application.Contexts.Stores.Queries.GetUserStores;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MerchandiseManager.Api.Controllers
{
	public class StoresController : BaseController
	{
		[HttpGet]
		public async Task<IActionResult> Get()
			=> Ok(await Mediator.Send(new GetUserStoresQuery()));

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] AddNewStoreCommand request)
		{
			await Mediator.Send(request);

			return NoContent();
		}
	}
}
