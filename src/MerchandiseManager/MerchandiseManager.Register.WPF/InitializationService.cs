using MerchandiseManager.Register.DAL.Repositories;
using System;
using System.Configuration;

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
			var productsRepository = new ProductsRepository(connectionString);


		}

	}
}
