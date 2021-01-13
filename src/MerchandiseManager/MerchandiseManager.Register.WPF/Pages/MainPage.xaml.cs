using MerchandiseManager.Register.WPF.Windows;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MerchandiseManager.Register.WPF.Pages
{
	/// <summary>
	/// Interaction logic for MainPage.xaml
	/// </summary>
	public partial class MainPage : Page
	{
		public MainPage()
		{
			InitializeComponent();
		}

		private void Window_KeyDown(object sender, KeyEventArgs e)
		{
			// check timing (keystrokes within 100 ms)
			TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
			if (elapsed.TotalMilliseconds > 100)
				_barcode.Clear();

			var keyChar = KeyInterop.VirtualKeyFromKey(e.Key);

			// process barcode
			if (keyChar == 13 && _barcode.Count > 0)
			{
				string msg = string.Join("", _barcode);
				//MessageBox.Show(msg); // Do something
				_barcode.Clear();
			}
			else
			{
				// record keystroke & timestamp
				_barcode.Add((char)keyChar);
				_lastKeystroke = DateTime.Now;
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			var loginForm = new LoginWindow();

			loginForm.Show();
		}

		private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}

		DateTime _lastKeystroke = new DateTime(0);
		List<char> _barcode = new List<char>(20);

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			var window = Window.GetWindow(this);

			window.KeyDown += Window_KeyDown;
		}
	}
}
