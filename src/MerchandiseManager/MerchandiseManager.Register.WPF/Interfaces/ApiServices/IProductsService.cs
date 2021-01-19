using System;
using System.Collections.Generic;
using System.Text;
using MerchandiseManager.Register.WPF.Persistence.Entities;

namespace MerchandiseManager.Register.WPF.Interfaces.ApiServices
{
	public interface IProductsService
	{
		IEnumerable<Product> GetAllProducts();
	}
}
