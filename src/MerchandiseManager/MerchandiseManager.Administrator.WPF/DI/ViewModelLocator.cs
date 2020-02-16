using MerchandiseManager.Administrator.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseManager.Administrator.WPF.DI
{
	public class ViewModelLocator
	{
		public static ViewModelLocator Instance { get; private set; } = new ViewModelLocator();

		public static MainWindowViewModel MainWindowViewModel => IoC.Get<MainWindowViewModel>();
		//public static AddEditDialogWindowViewModel
	}
}
