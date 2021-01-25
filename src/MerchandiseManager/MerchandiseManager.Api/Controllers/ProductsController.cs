using MerchandiseManager.Application.Contexts.Products.Commands.AddNewProduct;
using MerchandiseManager.Application.Contexts.Products.Commands.DeleteProduct;
using MerchandiseManager.Application.Contexts.Products.Commands.EditProduct;
using MerchandiseManager.Application.Contexts.Products.Queries.GetAllProducts;
using MerchandiseManager.Application.Contexts.Products.Queries.GetProductsByStorageId;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MerchandiseManager.Api.Controllers
{
	public class ProductsController : BaseController
	{
		[HttpPost]
		public async Task<IActionResult> AddNewProduct([FromBody] AddNewProductCommand request)
			=> Ok(await Mediator.Send(request));

		[HttpPut("{id}")]
		public async Task<IActionResult> EditProduct([FromRoute]Guid id, [FromBody] EditProductCommand request)
		{
			request.Id = id;
			return Ok(await Mediator.Send(request));
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteProduct(Guid id)
			=> Ok(await Mediator.Send(new DeleteProductCommand(id)));

		[HttpGet]
		public async Task<IActionResult> GetAll([FromQuery] GetAllProductsQuery request)
			=> Ok(await Mediator.Send(request));
	}
}
