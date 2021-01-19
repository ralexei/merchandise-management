using MerchandiseManager.Register.DAL.Interfaces.Persistence;
using MerchandiseManager.Register.WPF.Interfaces.Persistence;
using MerchandiseManager.Register.WPF.Persistence.Entities;

namespace MerchandiseManager.Register.DAL.Repositories
{
	public class ProductsRepository : GenericRepository<Product>, IProductsRepository
	{
		public ProductsRepository(string connectionString) : base(connectionString)
		{
		}
	}
}
