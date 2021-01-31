using MerchandiseManager.Register.WPF.Models.Request;
using MerchandiseManager.Register.WPF.Models.Response;
using MerchandiseManager.Register.WPF.Services.Api;
using System;
using System.Configuration;
using System.Windows;

namespace MerchandiseManager.Register.WPF.Windows
{
	/// <summary>
	/// Interaction logic for LoginWindow.xaml
	/// </summary>
	public partial class LoginWindow : Window
	{
		public LoginWindow()
		{
			InitializeComponent();
			InitializeStoresList();
		}

		private void InitializeStoresList()
		{
			var storesService = new StoresService(ConfigurationManager.AppSettings["ApiUrl"]);
			var stores = storesService.GetStores();

			StoresDropdown.ItemsSource = stores;
		}

		private void LoginButton_Click(object sender, RoutedEventArgs e)
		{
			var authService = new AuthApiService(ConfigurationManager.AppSettings["ApiUrl"]);

			if (StoresDropdown.SelectedItem != null &&
				!string.IsNullOrEmpty(UsernameField.Text) &&
				!string.IsNullOrEmpty(PasswordField.Password))
			{
				var selectedStore = (StorageViewModel)StoresDropdown.SelectedItem;

				var request = new LoginRequest
				{
					Username = UsernameField.Text,
					Password = PasswordField.Password,
					StoreId = selectedStore.Id
				};

				if (authService.Authenticate(request))
				{
					var mainWindow = new MainWindow();

					Application.Current.MainWindow = mainWindow;

					InitializationService.Instance.InitializeDb();

					Close(); //Close this window

					mainWindow.Show();
				}
				else
				{
					MessageBox.Show("Не удалось авторизироваться");
				}
			}
		}
	}
}
