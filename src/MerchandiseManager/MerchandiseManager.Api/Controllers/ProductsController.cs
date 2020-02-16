using MerchandiseManager.Application.Contexts.Products.Commands.AddNewProduct;
using MerchandiseManager.Application.Contexts.Products.Queries.GetAllProducts;
using MerchandiseManager.Application.Contexts.Products.Queries.GetProductsByStorageId;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MerchandiseManager.Api.Controllers
{
	public class ProductsController : BaseController
	{
		[HttpPost]
		public async Task<IActionResult> AddNewProduct([FromBody] AddNewProductCommand request)
			=> Ok(await Mediator.Send(request));

		[HttpGet]
		public async Task<IActionResult> GetAll([FromQuery] GetAllProductsQuery request)
			=> Ok(await Mediator.Send(request));

		[HttpGet("{storageId}")]
		public async Task<IActionResult> GetAllByStorageId([FromQuery]GetProductsByStorageIdQuery request)
			=> Ok(await Mediator.Send(request));
	}
}
