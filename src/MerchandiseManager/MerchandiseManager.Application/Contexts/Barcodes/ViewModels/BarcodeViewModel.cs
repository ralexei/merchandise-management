using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Application.Contexts.Barcodes.ViewModels
{
	public class BarcodeViewModel
	{
		public string RawCode { get; set; }

		public Guid ProductId { get; set; }
	}
}
