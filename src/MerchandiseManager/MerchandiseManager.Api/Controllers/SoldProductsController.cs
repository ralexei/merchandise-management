using MerchandiseManager.Application.Contexts.SoldProducts.Commands.SellProductsFromCart;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MerchandiseManager.Api.Controllers
{
	[Route("api/sold-products")]
	public class SoldProductsController : BaseController
	{
		[HttpGet]
		public async Task<IActionResult> GetAll()
			=> NotFound();

		[HttpPost]
		public async Task<IActionResult> SellProducts([FromBody] SellProductsFromCartCommand request)
		{
			await Mediator.Send(request);

			return Ok();
		}
	}
}
