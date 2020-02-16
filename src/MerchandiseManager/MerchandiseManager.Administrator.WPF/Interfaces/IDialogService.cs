using MerchandiseManager.Administrator.WPF.Models;
using MerchandiseManager.Administrator.WPF.ViewModels.Base;
using System.Windows;

namespace MerchandiseManager.Administrator.WPF.Interfaces
{
	public interface IDialogService
	{
		DialogWindowResult<TVM> ShowDialog<T, TVM>()
			where T : Window, new()
			where TVM : BaseDialogViewModel;

		DialogWindowResult<TVM> ShowDialog<T, TVM>(Window ownerWindow)
			where T : Window, new()
			where TVM : BaseDialogViewModel;

		DialogWindowResult<TVM> ShowDialog<T, TVM>(Window ownerWindow, TVM viewModel)
			where T : Window, new()
			where TVM : BaseDialogViewModel;
	}
}
