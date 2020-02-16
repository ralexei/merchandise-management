using MerchandiseManager.Administrator.WPF.Interfaces.Services.ApiServices;
using MerchandiseManager.Administrator.WPF.Interfaces.Utils;
using MerchandiseManager.Administrator.WPF.Models.ViewModels.Storage;
using MerchandiseManager.Administrator.WPF.Utils;
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

		public async Task CreateStorageAsync(CreateStorageRequest request)
		{
			await apiConnector.PostAsync("storages", request);
		}

		public IEnumerable<Storage> GetStorages()
		{
			return apiConnector.GetAsync<IEnumerable<Storage>>("storages").Result;
		}
	}
}
