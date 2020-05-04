using System;

namespace MerchandiseManager.PrinterService.Models
{
	public class PrintRequest
	{
		public int LabelsCount { get; set; }

		public string BarcodeToPrint { get; set; }

		public PrintingProductData PrintingProduct { get; set; }

		public class PrintingProductData
		{
			public string ProductName { get; set; }
			public string Price { get; set; }
		}
	}
}
