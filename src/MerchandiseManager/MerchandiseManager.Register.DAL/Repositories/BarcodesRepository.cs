using MerchandiseManager.Register.DAL.Interfaces.Persistence;
using MerchandiseManager.Register.WPF.Interfaces.Persistence;
using MerchandiseManager.Register.WPF.Persistence.Entities;

namespace MerchandiseManager.Register.DAL.Repositories
{
	public class BarcodesRepository : GenericRepository<BarCode>, IBarcodesRepository
	{
		public BarcodesRepository(string connectionString) : base(connectionString)
		{
		}
	}
}
