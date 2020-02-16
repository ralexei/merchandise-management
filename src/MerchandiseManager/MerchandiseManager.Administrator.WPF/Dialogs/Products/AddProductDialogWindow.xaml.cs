using MerchandiseManager.Administrator.WPF.DI;
using MerchandiseManager.Administrator.WPF.ViewModels.Dialogs.Products;
using System.Windows;

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
	}
}
