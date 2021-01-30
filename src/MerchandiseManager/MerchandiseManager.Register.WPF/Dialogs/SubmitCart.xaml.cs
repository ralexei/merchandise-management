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
using System.Windows.Shapes;

namespace MerchandiseManager.Register.WPF.Dialogs
{
	/// <summary>
	/// Логика взаимодействия для SubmitCart.xaml
	/// </summary>
	public partial class SubmitCart : Window
	{
		private readonly decimal totalToPay;

		public decimal ChangeSum { get; set; }
		public decimal ReceivedAmount { get; set; }

		public SubmitCart(decimal totalToPay)
		{
			InitializeComponent();

			this.totalToPay = totalToPay;

			TotalToPay.Text = totalToPay.ToString();
		}

		private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (decimal.TryParse(ReceivedSum.Text, out var receivedSum))
			{
				ChangeSum = receivedSum - totalToPay;
				ReceivedAmount = ReceivedAmount;

				Change.Text = ChangeSum.ToString();
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (decimal.TryParse(ReceivedSum.Text, out var receivedSum))
			{
				DialogResult = true;
			}
		}
	}
}
