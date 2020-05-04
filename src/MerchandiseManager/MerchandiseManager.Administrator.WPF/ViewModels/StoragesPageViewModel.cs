using log4net;
using MerchandiseManager.Administrator.WPF.Dialogs.Storages;
using MerchandiseManager.Administrator.WPF.Interfaces;
using MerchandiseManager.Administrator.WPF.Interfaces.Services.ApiServices;
using MerchandiseManager.Administrator.WPF.Models.ViewModels.Storage;
using MerchandiseManager.Administrator.WPF.ViewModels.Base;
using MerchandiseManager.Administrator.WPF.ViewModels.Dialogs.Storages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace MerchandiseManager.Administrator.WPF.ViewModels
{
	public class StoragesPageViewModel : BaseDialogViewModel
	{
		private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		private readonly IStoragesService storagesService;
		private readonly IDialogService dialogService;

		public ObservableCollection<Warehouse> Warehouses { get; set; }
		
		public ICommand AddStorageDialogCommand { get; set; }

		public StoragesPageViewModel(IStoragesService storagesService, IDialogService dialogService)
		{
			this.storagesService = storagesService;
			this.dialogService = dialogService;

			AddStorageDialogCommand = new RelayCommand(OpenAddStorageDialog);

			try
			{
				LoadWarehouses();
			}
			catch (Exception ex)
			{
				Log.Error(ex);
			}
		}

		private void OpenAddStorageDialog()
		{
			var dialog = dialogService.ShowDialog<AddStorageDialogWindow, AddStorageDialogViewModel>();

			if (dialog.DialogResult == true)
				Warehouses.Add(dialog.ResultInfo.CreatedWarehouse);
		}
		
		private async void LoadWarehouses()
		{
			try
			{
				Warehouses = new ObservableCollection<Warehouse>(await storagesService.GetWarehouses());
			}
			catch(Exception ex)
			{
				Log.Error(ex);
			}
		}
	}
}
