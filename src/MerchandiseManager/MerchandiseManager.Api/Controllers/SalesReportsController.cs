using MerchandiseManager.Application.Contexts.SalesReports.Queries.GetSalesReports;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MerchandiseManager.Api.Controllers
{
	[Route("api/sales-reports")]
	public class SalesReportsController : BaseController
	{
		[HttpGet("{storeId}")]
		public async Task<IActionResult> GetSalesReports([FromQuery] GetSalesReportsQuery request)
			=> Ok(await Mediator.Send(request));
	}
}
