using MerchandiseManager.Administrator.WPF.DI;
using MerchandiseManager.Administrator.WPF.ViewModels;

namespace MerchandiseManager.Administrator.WPF.Pages
{
	/// <summary>
	/// Interaction logic for HomePage.xaml
	/// </summary>
	public partial class HomePage : BasePage<HomePageViewModel>
	{
		public HomePage()
		{
			InitializeComponent();
		}

		private void HomePageMenu_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			IoC.Get<MainWindowViewModel>().CurrentPage = (HomePageMenu.SelectedItem as MenuItem).AssociatedPage;
		}
	}
}
