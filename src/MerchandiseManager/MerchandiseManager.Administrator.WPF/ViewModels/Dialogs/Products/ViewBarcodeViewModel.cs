using BarcodeLib;
using MerchandiseManager.Administrator.WPF.Models.ViewModels.Products;
using MerchandiseManager.Administrator.WPF.ViewModels.Base;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace MerchandiseManager.Administrator.WPF.ViewModels.Dialogs.Products
{
	public class ViewBarcodeViewModel : BaseDialogViewModel
	{
		private Image barcodeImage;
		private string rawBarcode;

		public Product Product { get; set; }
		public BitmapImage BarcodeBitmap { get; set; }
		public int LabelsNumber { get; set; } = 1;

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
					pd.PrintPage += new PrintPageEventHandler(pdPrintLabel);
					
					for (int i = 0; i < LabelsNumber; i++)
					{
						pd.Print();
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(JsonConvert.SerializeObject(ex), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
		}

		private void InitBarcodeImage(string barcodeValue)
		{
			var b = new Barcode();

			barcodeImage = b.Encode(TYPE.CODE39, barcodeValue, Color.Black, Color.White, 165, 20);

			BarcodeBitmap = Convert(barcodeImage);
		}

		private void pdPrintLabel(object sender, PrintPageEventArgs ev)
		{
			ev.Graphics.DrawString(Product.ProductName, new Font("arial", 8), new SolidBrush(Color.Black), 8, 6);
			ev.Graphics.DrawImage(barcodeImage, 8, 45);
			ev.Graphics.DrawString(rawBarcode, new Font("arial", 8), new SolidBrush(Color.Black), 55, 70);
			ev.Graphics.DrawString($"Total (lei): {Product.RetailSellPrice}", new Font("arial", 12), new SolidBrush(Color.Black), 55, 85);
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
