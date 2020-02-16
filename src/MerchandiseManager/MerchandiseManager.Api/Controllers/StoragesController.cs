using MerchandiseManager.Application.Contexts.Storages.Commands.AddNewStorage;
using MerchandiseManager.Application.Contexts.Storages.Queries.GetUserStorages;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MerchandiseManager.Api.Controllers
{
	public class StoragesController : BaseController
	{
		[HttpGet]
		public async Task<IActionResult> Get()
			=> Ok(await Mediator.Send(new GetUserStoragesQuery()));

		[HttpPost]
		public async Task<IActionResult> Create([FromBody]AddNewStorageCommand request)
			=> Ok(await Mediator.Send(request));
	}
}
