using MerchandiseManager.Administrator.WPF.DI;
using MerchandiseManager.Administrator.WPF.Interfaces;
using MerchandiseManager.Administrator.WPF.Models;
using MerchandiseManager.Administrator.WPF.ViewModels.Base;
using System.Windows;

namespace MerchandiseManager.Administrator.WPF.Services
{
	public class DialogService : IDialogService
	{
		public DialogWindowResult<TVM> ShowDialog<T, TVM>()
			where T : Window, new()
			where TVM : BaseDialogViewModel
		{
			return ShowDialog<T, TVM>(Application.Current.MainWindow);
		}

		public DialogWindowResult<TVM> ShowDialog<T, TVM>(Window ownerWindow)
			where T : Window, new()
			where TVM : BaseDialogViewModel
		{
			return ShowDialog<T, TVM>(ownerWindow, IoC.Get<TVM>());
		}

		public DialogWindowResult<TVM> ShowDialog<T, TVM>(Window ownerWindow, TVM viewModel)
			where T : Window, new()
			where TVM : BaseDialogViewModel
		{
			var dialogWindow = new T();

			dialogWindow.Owner = ownerWindow;

			viewModel.Window = dialogWindow;
			dialogWindow.DataContext = viewModel;

			return new DialogWindowResult<TVM>
			{
				DialogResult = dialogWindow.ShowDialog(),
				ResultInfo = viewModel
			};
		}
	}
}
