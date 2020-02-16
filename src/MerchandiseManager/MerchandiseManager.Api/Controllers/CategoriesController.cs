using MerchandiseManager.Application.Contexts.Categories.Commands.CreateCategory;
using MerchandiseManager.Application.Contexts.Categories.Queries.GetAllCategories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MerchandiseManager.Api.Controllers
{
	public class CategoriesController : BaseController
	{
		[HttpPost]
		public async Task<IActionResult> Create([FromBody]CreateCategoryCommand request)
			=> Ok(await Mediator.Send(request));

		[HttpGet]
		public async Task<IActionResult> Get()
			=> Ok(await Mediator.Send(new GetAllCategoriesQuery()));
	}
}
