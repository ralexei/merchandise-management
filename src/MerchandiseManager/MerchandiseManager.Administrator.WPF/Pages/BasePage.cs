using MerchandiseManager.Administrator.WPF.DI;
using MerchandiseManager.Administrator.WPF.ViewModels.Base;
using System.Windows.Controls;

namespace MerchandiseManager.Administrator.WPF.Pages
{
	public class BasePage<TVM> : Page
		where TVM : BaseViewModel
	{
		private TVM viewModel;

		public TVM ViewModel
		{
			get { return viewModel; }
		
			set
			{
				if (viewModel == value)
					return;

				viewModel = value;

				DataContext = viewModel;
			}
		}

		public BasePage()
		{
			ViewModel = IoC.Get<TVM>();
		}
	}
}
