using MerchandiseManager.Register.DAL;
using MerchandiseManager.Register.DAL.Repositories;
using MerchandiseManager.Register.WPF.Services.Api;
using System;
using System.Configuration;
using System.Linq;

namespace MerchandiseManager.Register.WPF
{
	public class InitializationService
	{
		private static readonly Lazy<InitializationService> _instance = new Lazy<InitializationService>(() => new InitializationService());
		public static InitializationService Instance { get { return _instance.Value; } }

		private InitializationService() { }

		public void InitializeDb()
		{
			var connectionString = ConfigurationManager.AppSettings["DbConnectionString"];
			var apiUrl = ConfigurationManager.AppSettings["ApiUrl"];
			var productsRepository = new ProductsRepository(connectionString);
			var barcodesRepository = new BarcodesRepository(connectionString);
			var productsApiService = new ProductsApiService(apiUrl);
			var allProducts = productsApiService.GetAllProducts();
			var context = new RegisterDbContext(connectionString);

			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();
			var barcodes = allProducts.Data.SelectMany(s => s.BarCodes);

			productsRepository.Add(allProducts.Data);
			barcodesRepository.Add(barcodes);
		}

	}
}
