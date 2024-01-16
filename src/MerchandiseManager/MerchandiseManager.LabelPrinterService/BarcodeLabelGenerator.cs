using BarcodeStandard;
using MerchandiseManager.PrinterService.Models;
using SkiaSharp;
using SkiaSharp.Views.Desktop;
using System.Drawing;

namespace MerchandiseManager.LabelPrinterService;

public class BarcodeLabelGenerator
{
	private const int DpiX = 100;
	private const int DpiY = 100;
	private const int LabelWidth = (int)(3.97 * DpiX);
	private const int LabelHeight = (int)(2.39 * DpiY);
	private const int PriceFontSize = 24;
	private const int ProductNameFontSize = 24;
	private const int ProductNameTopMargin = 4;
	private const int ProductNameLeftMargin = 6;

	/// <summary>
	/// Generate a bitmap for the label to be printed
	/// </summary>
	/// <param name="request"></param>
	/// <returns>Label's bitmap</returns>
	public Bitmap GenerateLabelImage(PrintRequest request)
	{
		var barcode = new Barcode();

		barcode.IncludeLabel = true;
		barcode.Alignment = AlignmentPositions.Center;
		barcode.LabelFont = new SKFont(SKTypeface.Default, 18);

		var encodedBarcode = barcode.Encode(Type.Code39, request.BarcodeToPrint, (int)LabelWidth, (int)(LabelHeight * 0.3));

		using (var surface = SKSurface.Create(new SKImageInfo(LabelWidth, LabelHeight)))
		{
			var canvas = surface.Canvas;
			canvas.Clear(SKColors.White);

			// Draw product name on the label's bitmap
			canvas.DrawText(request.PrintingProduct.ProductName, ProductNameLeftMargin, ProductNameFontSize + ProductNameTopMargin, new SKPaint { Color = SKColors.Black, TextSize = ProductNameFontSize });

			SKBitmap barcodeBitmap = SKBitmap.FromImage(encodedBarcode);

			// Draw the barcode on the label
			canvas.DrawBitmap(barcodeBitmap, new SKPoint(XCentered(barcodeBitmap.Width, LabelWidth), LabelHeight - barcodeBitmap.Height - 10));

			var priceString = "Total (lei): " + request.PrintingProduct.Price.ToString() + " MDL";
			var priceStringMeasure = new SKRect();
			var pricePaint = new SKPaint { TextSize = 8 };
			pricePaint.MeasureText(priceString, ref priceStringMeasure);

			var priceRectYPosition = LabelHeight - barcodeBitmap.Height - priceStringMeasure.Height - 15;

			// Draw the price
			canvas.DrawText(priceString, 5, priceRectYPosition, new SKPaint { Color = SKColors.Black, TextSize = PriceFontSize });

			using (var skImage = surface.Snapshot())
			{
				var skBitmap = SKBitmap.FromImage(skImage);
				var bitmap = skBitmap.ToBitmap();

				// TEST PURPOSE
				//bitmap.Save("file.png", ImageFormat.Png);

				return skBitmap.ToBitmap();
			}
		}
	}

	private float XCentered(float localWidth, float globalWidth)
	{
		return ((globalWidth - localWidth) / 2);
	}
}
