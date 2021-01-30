using DapperExtensions;
using MerchandiseManager.Register.DAL.Interfaces.Persistence;
using MerchandiseManager.Register.WPF.Interfaces.Persistence;
using MerchandiseManager.Register.WPF.Persistence.Entities;
using Microsoft.Data.Sqlite;
using System.Linq;

namespace MerchandiseManager.Register.DAL.Repositories
{
	public class ProductsRepository : GenericRepository<Product>, IProductsRepository
	{
		public ProductsRepository(string connectionString) : base(connectionString)
		{
		}

		public Product GetByBarcode(string barcode)
		{
			using (var connection = new SqliteConnection(connectionString))
			{
				connection.Open();

				var predicate = Predicates.Field<BarCode>(f => f.RawCode, Operator.Eq, barcode);
				var barcodeEntity = connection.GetList<BarCode>(predicate).FirstOrDefault();
				var barcodes = connection.GetList<BarCode>();
				if (barcodeEntity == null)
					return null;

				var productEntity = connection.Get<Product>(barcodeEntity.ProductId);

				connection.Close();

				return productEntity;
			}
		}
	}
}
