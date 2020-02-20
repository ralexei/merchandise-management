using MerchandiseManager.Administrator.WPF.Models.ViewModels.Categories;
using MerchandiseManager.Administrator.WPF.ViewModels.Dialogs.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace MerchandiseManager.Administrator.WPF.Dialogs.Products
{
	/// <summary>
	/// Interaction logic for ViewProductDialogWindow.xaml
	/// </summary>
	public partial class ViewProductDialogWindow : Window
	{
		public ViewProductDialogWindow()
		{
			InitializeComponent();
		}

		private void BarcodeDoubleClick(object sender, MouseButtonEventArgs e)
		{
			((EditProductViewModel)DataContext).ViewBarcode(((ListBoxItem)sender).Content.ToString());
		}

		private void Hyperlink_Click(object sender, RoutedEventArgs e)
		{
			var vm = DataContext as EditProductViewModel;

			vm.DeleteBarcode(((Hyperlink)sender).Tag.ToString());
		}
	}
}
