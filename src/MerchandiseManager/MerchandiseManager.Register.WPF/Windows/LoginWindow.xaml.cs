using MerchandiseManager.Register.WPF.Models.Request;
using MerchandiseManager.Register.WPF.Services.Api;
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
		}

		private void LoginButton_Click(object sender, RoutedEventArgs e)
		{
			var authService = new AuthApiService(ConfigurationManager.AppSettings["ApiUrl"]);
			if (authService.Authenticate(new LoginRequest { Username = UsernameField.Text, Password = PasswordField.Password }))
			{
				var mainWindow = new MainWindow();

				Application.Current.MainWindow = mainWindow;

				InitializationService.Instance.InitializeDb();

				Close(); //Close this window

				mainWindow.Show();
			}
		}
	}
}
