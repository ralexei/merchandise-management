using MerchandiseManager.Administrator.WPF.DI;
using MerchandiseManager.Administrator.WPF.ViewModels.Dialogs.Products;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace MerchandiseManager.Administrator.WPF.Dialogs.Products
{
	/// <summary>
	/// Interaction logic for AddProductDialogWindow.xaml
	/// </summary>
	public partial class AddProductDialogWindow : Window
	{
		public AddProductDialogWindow()
		{
			InitializeComponent();

			//DataContext = IoC.Get<AddProductDialogViewModel>();
		}

		private void BarcodeDoubleClick(object sender, MouseButtonEventArgs e)
		{
			((AddProductDialogViewModel)DataContext).ViewBarcode(((ListBoxItem)sender).Content.ToString());
		}

		private void Hyperlink_Click(object sender, RoutedEventArgs e)
		{
			var vm = DataContext as AddProductDialogViewModel;

			vm.DeleteBarcode(((Hyperlink)sender).Tag.ToString());
		}
	}
}
