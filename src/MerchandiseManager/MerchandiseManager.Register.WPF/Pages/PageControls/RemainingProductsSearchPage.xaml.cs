using MerchandiseManager.Register.WPF.Models.Common;
using MerchandiseManager.Register.WPF.Models.Response;
using MerchandiseManager.Register.WPF.Services.Api;
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
	/// Логика взаимодействия для RemainingProductsSearchPage.xaml
	/// </summary>
	public partial class RemainingProductsSearchPage : UserControl
	{
		public RemainingProductsSearchPage()
		{
			InitializeComponent();
		}

		private void SearchProductRemainings(object sender, RoutedEventArgs e)
		{
			var productsService = new ProductsApiService(ConfigurationManager.AppSettings["ApiUrl"]);
			if (ProductToSearchTerm.Text?.Length > 2)
			{
				var availableProducts = productsService.GetProductAvailability(ProductToSearchTerm.Text);

				RemainingProductsList.ItemsSource = availableProducts;
			}
		}
	}
}
