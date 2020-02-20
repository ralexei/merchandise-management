using MerchandiseManager.Administrator.WPF.Models.ViewModels.Products;
using MerchandiseManager.Administrator.WPF.ViewModels;
using System.Windows.Input;

namespace MerchandiseManager.Administrator.WPF.Pages
{
	/// <summary>
	/// Interaction logic for ProductsPage.xaml
	/// </summary>
	public partial class ProductsPage : BasePage<ProductsPageViewModel>
	{
		public ProductsPage()
		{
			InitializeComponent();
		}

		private void ProductDoubleClick(object sender, MouseButtonEventArgs e)
		{
			ViewModel.EditProduct(sender as Product);
		}
	}
}
