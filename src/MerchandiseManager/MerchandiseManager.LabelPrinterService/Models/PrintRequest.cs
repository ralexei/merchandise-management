namespace MerchandiseManager.PrinterService.Models
{
	public class PrintRequest
	{
		/// <summary>
		/// How many labels to print
		/// </summary>
		public int LabelsCount { get; set; }

		/// <summary>
		/// The barcode data to encode
		/// </summary>
		public string BarcodeToPrint { get; set; }

		/// <summary>
		/// Product details to print across the label
		/// </summary>

		public PrintingProductData PrintingProduct { get; set; }
	}

	public class PrintingProductData
	{
		public string ProductName { get; set; }
		public decimal Price { get; set; }
	}
}
