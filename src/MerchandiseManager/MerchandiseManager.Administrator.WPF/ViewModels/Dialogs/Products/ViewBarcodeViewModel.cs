using BarcodeLib;
using MerchandiseManager.Administrator.WPF.ViewModels.Base;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace MerchandiseManager.Administrator.WPF.ViewModels.Dialogs.Products
{
	public class ViewBarcodeViewModel : BaseDialogViewModel
	{
		private Image barcodeImage;
		private string rawBarcode;

		public BitmapImage BarcodeBitmap { get; set; }

		public string RawBarcode
		{
			get
			{
				return rawBarcode;
			}
			set
			{
				InitBarcodeImage(value);
				rawBarcode = value;
			}
		}

		public ICommand PrintBarcodeCommand { get; set; }

		public ViewBarcodeViewModel()
		{
			PrintBarcodeCommand = new RelayCommand(PrintBarcode);
		}

		public void PrintBarcode()
		{

			using (PrintDocument pd = new PrintDocument())
			{
				try
				{
					pd.PrintController = new StandardPrintController();
					pd.PrinterSettings.PrinterName = "Xprinter_XP-370B";
					pd.PrinterSettings.DefaultPageSettings.PaperSize = new PaperSize("", 19000, 12000);
					pd.PrintPage += new PrintPageEventHandler(pdPrintLabel);
					pd.Print();
				}
				catch (Exception ex) { }
			}
		}

		private void InitBarcodeImage(string barcodeValue)
		{
			var b = new Barcode();

			barcodeImage = b.Encode(TYPE.CODE39, barcodeValue, Color.Black, Color.White, 165, 50);
			BarcodeBitmap = Convert(barcodeImage);
		}

		private void pdPrintLabel(object sender, PrintPageEventArgs ev)
		{
			ev.Graphics.DrawImage(barcodeImage, 8, 10);
			ev.Graphics.DrawString(rawBarcode, new Font("arial", 8), new SolidBrush(Color.Black), 55, 65);
		}

		public BitmapImage Convert(Image img)
		{
			using (var memory = new MemoryStream())
			{
				img.Save(memory, ImageFormat.Png);
				memory.Position = 0;

				var bitmapImage = new BitmapImage();
				bitmapImage.BeginInit();
				bitmapImage.StreamSource = memory;
				bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
				bitmapImage.EndInit();

				return bitmapImage;
			}
		}
	}
}
