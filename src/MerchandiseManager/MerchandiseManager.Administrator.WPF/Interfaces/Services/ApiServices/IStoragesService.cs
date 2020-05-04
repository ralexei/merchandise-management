using MerchandiseManager.Administrator.WPF.Models.ViewModels.Storage;
using MerchandiseManager.Administrator.WPF.ViewModels.Dialogs.Storages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MerchandiseManager.Administrator.WPF.Interfaces.Services.ApiServices
{
	public interface IStoragesService
	{
		Task<Warehouse> CreateWarehouseAsync(AddStorageDialogViewModel request);
		Task<IEnumerable<Warehouse>> GetWarehouses();
	}
}
