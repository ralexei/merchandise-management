using MerchandiseManager.Administrator.WPF.Interfaces.Services.ApiServices;
using MerchandiseManager.Administrator.WPF.Models.Enums;
using MerchandiseManager.Administrator.WPF.ViewModels.Base;

namespace MerchandiseManager.Administrator.WPF.ViewModels
{
	public class MainWindowViewModel : BaseViewModel
	{
		public ApplicationPagesEnum CurrentPage { get; set; } = ApplicationPagesEnum.Storages;

		public MainWindowViewModel(IAuthService authService)
		{
			authService.Login("ralexei", "Test123!");
		}
	}
}
