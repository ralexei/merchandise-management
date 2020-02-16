using MerchandiseManager.Administrator.WPF.Interfaces.Services.ApiServices;
using MerchandiseManager.Administrator.WPF.Models.ViewModels.Storage;
using MerchandiseManager.Administrator.WPF.ViewModels.Base;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MerchandiseManager.Administrator.WPF.ViewModels.Dialogs.Storages
{
	public class AddStorageDialogViewModel : BaseDialogViewModel
	{
		private readonly IStoragesService storagesService;

		public ICommand SaveCommand { get; set; }

		public string StorageName { get; set; }
		public string StorageDescription { get; set; }

		public AddStorageDialogViewModel(IStoragesService storagesService)
		{
			this.storagesService = storagesService;

			SaveCommand = new RelayCommand(async () => await CreateStorage());
		}

		private async Task CreateStorage()
		{
			await storagesService.CreateStorageAsync(new CreateStorageRequest
			{
				StorageName = StorageName,
				StorageDescription = StorageDescription
			});
		}
	}
}
