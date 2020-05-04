using FontAwesome5;
using FontAwesome5.Converters;
using MerchandiseManager.Administrator.WPF.DI;
using MerchandiseManager.Administrator.WPF.Models.Enums;
using MerchandiseManager.Administrator.WPF.Utils;
using MerchandiseManager.Administrator.WPF.ViewModels;
using System;
using System.Collections.Generic;
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

namespace MerchandiseManager.Administrator.WPF
{
	public class MenuItem
	{
		public string Title { get; set; }
		public EFontAwesomeIcon Icon { get; set; }
		public ApplicationPagesEnum AssociatedPage { get; set; }

		public List<MenuItem> Children { get; set; } = new List<MenuItem>();

		public MenuItem(string title, EFontAwesomeIcon icon, List<MenuItem> children = null)
		{
			Title = title;
			Icon = icon;

			if (children != null)
				Children.AddRange(children);
		}

		public MenuItem AssociatePage (ApplicationPagesEnum page)
		{
			AssociatedPage = page;

			return this;
		}
	}

	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			DataContext = IoC.Get<MainWindowViewModel>();
		}

		private void Window_Loaded_1(object sender, RoutedEventArgs e)
		{
			MenuTreeView.Items.Add(MenuStorage.Menu);
		}

		private void MenuItemSelected(object sender, RoutedPropertyChangedEventArgs<object> e)
		{
			var selectedValue = (MenuItem)e.NewValue;

			IoC.Get<MainWindowViewModel>().CurrentPage = selectedValue.AssociatedPage;
		}
	}
}

