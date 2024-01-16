using MerchandiseManager.PrinterService.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Threading.Tasks;

namespace MerchandiseManager.LabelPrinterService
{
	public class PrinterHub : Hub
	{
		private static string PrinterName = "Xprinter_XP-370B";
		private readonly ILogger<PrinterHub> _logger;
		private readonly BarcodeLabelGenerator _barcodeLabelGenerator;

		public PrinterHub(ILogger<PrinterHub> logger, BarcodeLabelGenerator barcodeLabelGenerator)
        {
			_logger = logger;
			_barcodeLabelGenerator = barcodeLabelGenerator;
		}

        public override Task OnConnectedAsync()
		{
			return base.OnConnectedAsync();
		}

		public bool PrintLabel(PrintRequest request)
		{
			using (PrintDocument pd = new PrintDocument())
			{
				try
				{
					pd.PrintController = new StandardPrintController();
					pd.PrinterSettings.PrinterName = PrinterName;
					pd.PrintPage += (sender, args) => PrintLabelEvent(request, args);

					for (int i = 0; i < request.LabelsCount; i++)
					{
						pd.Print();
					}
				}
				catch (Exception ex)
				{
					_logger.LogError(ex, "Failed to print a label");
					return false;
				}
			}

			return true;
		}

		private void PrintLabelEvent(PrintRequest request, PrintPageEventArgs e)
		{
			var barcodeLabelBitmap = _barcodeLabelGenerator.GenerateLabelImage(request);

			e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
			e.Graphics.CompositingQuality = CompositingQuality.HighQuality;

			e.Graphics.DrawImage(barcodeLabelBitmap, new Point(0, 0));
		}
	}
}
