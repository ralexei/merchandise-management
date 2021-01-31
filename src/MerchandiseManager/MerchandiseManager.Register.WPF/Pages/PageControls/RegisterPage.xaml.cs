using MerchandiseManager.Register.DAL.Repositories;
using MerchandiseManager.Register.WPF.Dialogs;
using MerchandiseManager.Register.WPF.Models.Common;
using MerchandiseManager.Register.WPF.Services.Api;
using MerchandiseManager.Register.WPF.Utils;
using MerchandiseManager.Register.WPF.Windows;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MerchandiseManager.Register.WPF.Pages.PageControls
{
	/// <summary>
	/// Логика взаимодействия для RegisterPAge.xaml
	/// </summary>
	public partial class RegisterPage : UserControl
	{
		private readonly ProductsRepository productsRepository;
		private readonly KeyboardListener listener = new KeyboardListener();
		private static bool subscribed = false;

		public RegisterPage()
		{
			InitializeComponent();

			if (!subscribed)
			{
				listener.KeyDown += Window_KeyDown;
				subscribed = true;
			}

			productsRepository = new ProductsRepository(ConfigurationManager.AppSettings["DbConnectionString"]);
		}

		private void Window_KeyDown(object sender, RawKeyEventArgs e)
		{
			// check timing (keystrokes within 100 ms)
			TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
			if (elapsed.TotalMilliseconds > 100)
				_barcode.Clear();

			var keyChar = KeyInterop.VirtualKeyFromKey(e.Key);

			// process barcode
			if (keyChar == 13 && _barcode.Count > 0)
			{
				ProcessBarcodeAdd(new string(_barcode.ToArray()).Trim());
				_barcode.Clear();
			}
			else
			{
				// record keystroke & timestamp
				_barcode.Add((char)keyChar);
				_lastKeystroke = DateTime.Now;
			}
		}

		private void ProcessBarcodeAdd(string barcode)
		{
			var product = productsRepository.GetByBarcode(barcode);

			if (product != null)
				CartStorage.Instance.AddToCart(product);
			else
				MessageBox.Show("Не удалось добавить в корзину. Незнакомый товар.");

			CartProductsList.ItemsSource = CartStorage.Instance.GetCartProducts();

			GenerateSums();
		}

		private void GenerateSums()
		{
			Sum.Content = CartStorage.Instance.GetCartProducts().Sum(s => s.Sum);
			TotalToPay.Content = Sum.Content; // To do: Apply discount
		}

		DateTime _lastKeystroke = new DateTime(0);
		List<char> _barcode = new List<char>(20);

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			if (TotalToPay.Content != null &&
				decimal.TryParse(TotalToPay.Content.ToString(), out var totalToPay) && !CartStorage.Instance.Empty)
			{
				var confirmationDialog = new SubmitCart(totalToPay);

				if (confirmationDialog.ShowDialog().GetValueOrDefault())
				{
					var soldProductsService = new SoldProductsService(ConfigurationManager.AppSettings["ApiUrl"]);
					var result = soldProductsService.SubmitSoldCart(CartStorage.Instance.GetCartProducts(), confirmationDialog.ChangeSum, confirmationDialog.ReceivedAmount);

					if (!result)
						MessageBox.Show("Не удалось обработать заказ.");
					else
					{
						ClearCart();
					}
				}
			}
			SubmitButton.Focusable = false;
			Keyboard.ClearFocus();
		}

		private void DeleteProductFromCart(object sender, RoutedEventArgs e)
		{
			var objectData = ((Button)sender).DataContext;
			var data = (CartProduct)objectData;

			CartStorage.Instance.RemoveFromCart(data.ProductId);

			CartProductsList.ItemsSource = CartStorage.Instance.GetCartProducts();
			GenerateSums();
		}

		private void ClearCart(object sender, RoutedEventArgs e)
		{
			ClearCart();
			//((Button)sender).Focusable = false;
			Keyboard.ClearFocus();
		}

		private void ClearCart()
		{
			CartStorage.Instance.ClearCart();
			CartProductsList.ItemsSource = CartStorage.Instance.GetCartProducts();
			GenerateSums();
		}
	}
}
