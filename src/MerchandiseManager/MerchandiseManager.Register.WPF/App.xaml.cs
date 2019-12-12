using MerchandiseManager.Register.WPF.Windows;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MerchandiseManager.Register.WPF
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private void ApplicationStart(object sender, StartupEventArgs e)
		{
			Window login = new LoginWindow();

			login.Show();
		}
	}
}
