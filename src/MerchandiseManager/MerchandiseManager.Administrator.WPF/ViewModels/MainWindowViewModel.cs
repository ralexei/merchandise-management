using MerchandiseManager.Administrator.WPF.Interfaces.Services.ApiServices;
using MerchandiseManager.Administrator.WPF.Models.Enums;
using MerchandiseManager.Administrator.WPF.ViewModels.Base;
using System;
using System.Windows;

namespace MerchandiseManager.Administrator.WPF.ViewModels
{
	public class MainWindowViewModel : BaseViewModel
	{
		public ApplicationPagesEnum CurrentPage { get; set; } = ApplicationPagesEnum.Storages;
	}
}
