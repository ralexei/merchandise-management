using MerchandiseManager.Administrator.WPF.ViewModels.Base;
using System.Windows;

namespace MerchandiseManager.Administrator.WPF.ViewModels
{
	public class ModalWindowViewModel : BaseViewModel
	{
		private readonly Window window;

		public ModalWindowViewModel(Window window)
		{
			this.window = window;
		}
	}
}
