using MerchandiseManager.Application.Contexts.Categories.Queries.GetFlatCategories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MerchandiseManager.Api.Controllers
{
	[Route("api/flattened-categories")]
	public class FlattenedCategoriesController : BaseController
	{
		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> Get()
			=> Ok(await Mediator.Send(new GetFlatCategoriesQuery()));
	}
}
