using MerchandiseManager.Administrator.WPF.ViewModels.Base;
using System.Windows;
using System.Windows.Input;

namespace MerchandiseManager.Administrator.WPF.ViewModels.Dialogs.Products
{
	public class AddBarcodeDialogViewModel : BaseDialogViewModel
	{
		public string RawBarcode { get; set; }

		public ICommand DialogSubmitCommand { get; set; }
		public ICommand GenerateBarcodeCommand { get; set; }

		public AddBarcodeDialogViewModel()
		{
			DialogSubmitCommand = new RelayCommand(SubmitCommand);
			GenerateBarcodeCommand = new RelayCommand(GenerateBarcode);
		}

		private void GenerateBarcode()
		{

		}

		private void SubmitCommand()
		{
			Window.DialogResult = true;
		}
	}
}
