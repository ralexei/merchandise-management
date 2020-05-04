using log4net;
using MerchandiseManager.Administrator.WPF.Interfaces.Services.ApiServices;
using MerchandiseManager.Administrator.WPF.Models.ViewModels.Storage;
using MerchandiseManager.Administrator.WPF.ViewModels.Base;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MerchandiseManager.Administrator.WPF.ViewModels.Dialogs.Storages
{
	public class AddStorageDialogViewModel : BaseDialogViewModel
	{
		private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		private readonly IStoragesService storagesService;

		public ICommand SaveCommand { get; set; }

		public string Name { get; set; }
		public string Description { get; set; }

		public Warehouse CreatedWarehouse { get; set; }

		public AddStorageDialogViewModel(IStoragesService storagesService)
		{
			this.storagesService = storagesService;

			SaveCommand = new RelayCommand(async () => await CreateWarehouse());
		}

		private async Task CreateWarehouse()
		{
			Log.Info("Loggin CreateWarehouse");
			try
			{
				CreatedWarehouse = await storagesService.CreateWarehouseAsync(this);

				Window.DialogResult = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Неизвестная ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

				Log.Error(ex);
			}
		}
	}
}
