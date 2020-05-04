using MerchandiseManager.Administrator.WPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseManager.Administrator.WPF.ViewModels
{
	public class HomePageViewModel : BaseViewModel
	{
		public ObservableCollection<MenuItem> MenuItemsList { get; set; }

		public HomePageViewModel()
		{
			MenuItemsList = new ObservableCollection<MenuItem>(MenuStorage.Menu.Children);
		}
	}
}
