using MerchandiseManager.Administrator.WPF.DI;
using MerchandiseManager.Administrator.WPF.Services.ApiServices;
using System;
using System.Windows;

namespace MerchandiseManager.Administrator.WPF
{
	/// <summary>
	/// Interaction logic for LoginWindow.xaml
	/// </summary>
	public partial class LoginWindow : Window
	{
		public LoginWindow()
		{
			InitializeComponent();

			if (Application.Current.Properties["Username"] != null)
				Username.Text = Application.Current.Properties["Username"].ToString();
		}

		private void LoginButtonClick(object sender, RoutedEventArgs e)
		{
			var authService = IoC.Get<AuthService>();

			try
			{
				authService.Login(Username.Text, Password.Password);

				Application.Current.Properties["Username"] = Username.Text;

				var main = new MainWindow();
				Application.Current.MainWindow = main;

				Close();
				main.Show();
			}
			catch (Exception ex)
			{
				if (ex.InnerException is ArgumentException)
				{
					MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
				}
				else
				{
					MessageBox.Show("Неизвестная ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
		}
	}
}
