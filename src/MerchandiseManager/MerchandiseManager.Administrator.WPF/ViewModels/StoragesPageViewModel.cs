using MerchandiseManager.Administrator.WPF.Dialogs.Storages;
using MerchandiseManager.Administrator.WPF.Interfaces;
using MerchandiseManager.Administrator.WPF.Interfaces.Services.ApiServices;
using MerchandiseManager.Administrator.WPF.Models.ViewModels.Storage;
using MerchandiseManager.Administrator.WPF.ViewModels.Base;
using MerchandiseManager.Administrator.WPF.ViewModels.Dialogs.Storages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace MerchandiseManager.Administrator.WPF.ViewModels
{
	public class StoragesPageViewModel : BaseDialogViewModel
	{
		private readonly IDialogService dialogService;

		public List<Storage> Storages { get; set; }
		
		public ICommand AddStorageDialogCommand { get; set; }

		public StoragesPageViewModel(IStoragesService storagesService, IDialogService dialogService)
		{
			AddStorageDialogCommand = new RelayCommand(OpenAddStorageDialog);

			try
			{
				Storages = storagesService.GetStorages().ToList();
			}
			catch { }

			this.dialogService = dialogService;
		}

		private void OpenAddStorageDialog()
		{
			dialogService.ShowDialog<AddStorageDialogWindow, AddStorageDialogViewModel>();
		}
	}
}
