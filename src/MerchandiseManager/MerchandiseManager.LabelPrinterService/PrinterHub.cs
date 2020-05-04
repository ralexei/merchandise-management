using BarcodeLib;
using MerchandiseManager.PrinterService.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Threading.Tasks;

namespace MerchandiseManager.LabelPrinterService
{
	public class PrinterHub : Hub
	{
		private static string CommonFontName = "Arial";
		private static Font ProductNameFont = new Font(CommonFontName, 8);

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
					pd.PrinterSettings.PrinterName = "Xprinter_XP-370B";
					pd.PrintPage += (sender, args) => PrintLabelEvent(request, args);

					for (int i = 0; i < request.LabelsCount; i++)
					{
						pd.Print();
					}
				}
				catch (Exception ex)
				{
				}
			}

			return true;
		}

		private void PrintLabelEvent(PrintRequest request, PrintPageEventArgs e)
		{
			var barcode = new Barcode();

			barcode.IncludeLabel = true;
			var settings = e.PageSettings.PrinterSettings.PaperSizes;
			//var settings1 = e.PageSettings.PrinterSettings;
			//var settings2 = e.PageSettings.PrinterSettings.PaperSizes;
			barcode.LabelPosition = LabelPositions.BOTTOMCENTER;
			barcode.LabelFont = ProductNameFont;

			var dpiX = 100;
			var dpiY = 100;

			var labelWidth = (int)(1.96 * dpiX);
			var labelHeight = (int)(1.18 * dpiY);
			var encodedBarcode = barcode.Encode(TYPE.CODE39, request.BarcodeToPrint, (int)labelWidth, (int)(labelHeight * 0.3));

			e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
			e.Graphics.CompositingQuality = CompositingQuality.HighQuality;

			var priceString = "Total (lei): " + request.PrintingProduct.Price.ToString() + " MDL";
			var priceStringMeasure = e.Graphics.MeasureString(priceString, ProductNameFont);

			var drawFormat = new StringFormat { Alignment = StringAlignment.Near };

			// Draw product name
			var productNameRect = new RectangleF(5, 10, labelWidth - 10, (int)(labelHeight / 3));
			e.Graphics.DrawString(request.PrintingProduct.ProductName, ProductNameFont, new SolidBrush(Color.Black), productNameRect, drawFormat);

			// Draw barcode
			var barcodeBitmap = new Bitmap(encodedBarcode);
			barcodeBitmap.SetResolution(dpiX, dpiY);

			e.Graphics.DrawImage(barcodeBitmap, new Point((int)XCentered(barcodeBitmap.Width, labelWidth), (int)labelHeight - barcodeBitmap.Height - 10));

			// Draw price
			var priceRectYPosition = labelHeight - barcodeBitmap.Height - priceStringMeasure.Height - 15;
			var priceRect = new RectangleF(5, (int)priceRectYPosition, priceStringMeasure.Width, priceStringMeasure.Height);

			e.Graphics.DrawString(priceString, ProductNameFont, new SolidBrush(Color.Black), priceRect);
			//e.Graphics.PageUnit = GraphicsUnit.Pixel;
			//e.PageSettings.PrinterSettings.
			//e.Graphics.DrawRectangle(Pens.Black, new Rectangle(5, 5, 196 - 10, 118 - 10));

			e.Graphics.Save();
		}

		private float XCentered(float localWidth, float globalWidth)
		{
			return ((globalWidth - localWidth) / 2);
		}
	}
}
