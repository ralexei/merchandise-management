using MerchandiseManager.Application.Contexts.Warehouses.Commands.AddNewStorage;
using MerchandiseManager.Application.Contexts.Warehouses.Queries.GetUserWarehouses;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MerchandiseManager.Api.Controllers
{
	public class StoragesController : BaseController
	{
		[HttpGet]
		public async Task<IActionResult> Get()
			=> Ok(await Mediator.Send(new GetUserWarehousesQuery()));

		[HttpPost]
		public async Task<IActionResult> Create([FromBody]AddNewWarehouseCommand request)
			=> Ok(await Mediator.Send(request));
	}
}
