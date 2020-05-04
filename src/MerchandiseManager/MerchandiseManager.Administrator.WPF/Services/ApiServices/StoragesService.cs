using MerchandiseManager.Administrator.WPF.Interfaces.Services.ApiServices;
using MerchandiseManager.Administrator.WPF.Interfaces.Utils;
using MerchandiseManager.Administrator.WPF.Models.ViewModels.Storage;
using MerchandiseManager.Administrator.WPF.Utils;
using MerchandiseManager.Administrator.WPF.ViewModels.Dialogs.Storages;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MerchandiseManager.Administrator.WPF.Services.ApiServices
{
	public class StoragesService : IStoragesService
	{
		private readonly IApiConnector apiConnector;

		public StoragesService(IApiConnector apiConnector)
		{
			this.apiConnector = apiConnector;
		}

		public async Task<Warehouse> CreateWarehouseAsync(AddStorageDialogViewModel request)
		{
			return await apiConnector.PostAsync<Warehouse, AddStorageDialogViewModel>("storages", request);
		}

		public async Task<IEnumerable<Warehouse>> GetWarehouses()
		{
			return await apiConnector.GetAsync<IEnumerable<Warehouse>>("storages");
		}
	}
}
