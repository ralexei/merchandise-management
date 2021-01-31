﻿using MerchandiseManager.Application.Contexts.SoldProducts.ViewModels;
using System.Collections.Generic;

namespace MerchandiseManager.Application.Contexts.SalesReports.ViewModels
{
	public class SalesReportViewModel
	{
		public IEnumerable<SoldProductViewModel> SoldProducts { get; set; }
		public decimal TotalSum { get; set; }
		public decimal UserSoldAmount { get; set; }
	}
}
