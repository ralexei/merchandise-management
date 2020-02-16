using MerchandiseManager.Administrator.WPF.Models.ViewModels.Storage;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MerchandiseManager.Administrator.WPF.Interfaces.Services.ApiServices
{
	public interface IStoragesService
	{
		Task CreateStorageAsync(CreateStorageRequest request);
		IEnumerable<Storage> GetStorages();
	}
}
