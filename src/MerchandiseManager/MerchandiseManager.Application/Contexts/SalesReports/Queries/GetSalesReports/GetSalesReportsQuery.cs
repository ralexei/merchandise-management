using MediatR;
using MerchandiseManager.Application.Contexts.SalesReports.ViewModels;
using MerchandiseManager.Application.Interfaces.Models.Filtering;
using MerchandiseManager.Application.Models.Filtering;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Application.Contexts.SalesReports.Queries.GetSalesReports
{
	public class GetSalesReportsQuery : IPaginatable, IRequest<FilteredResult<SalesReportViewModel>>
	{
		[FromRoute]
		public Guid StoreId { get; set; }

		public long? FromDate { get; set; }
		public long? ToDate { get; set; }

		public int? Page { get; set; }
		public int? PageSize { get; set; }
	}
}
