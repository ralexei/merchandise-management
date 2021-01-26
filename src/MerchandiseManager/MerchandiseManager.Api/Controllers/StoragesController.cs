using MerchandiseManager.Application.Contexts.Storages.Queries.GetUserStorages;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MerchandiseManager.Api.Controllers
{
	public class StoragesController : BaseController
	{
		[HttpGet]
		public async Task<IActionResult> GetUserStorages()
			=> Ok(await Mediator.Send(new GetUserStoragesQuery()));
	}
}
