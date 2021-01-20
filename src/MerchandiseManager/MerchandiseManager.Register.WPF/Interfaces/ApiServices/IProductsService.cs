using System;
using System.Collections.Generic;
using System.Text;
using MerchandiseManager.Register.WPF.Models.Response;
using MerchandiseManager.Register.WPF.Persistence.Entities;

namespace MerchandiseManager.Register.WPF.Interfaces.ApiServices
{
	public interface IProductsService
	{
		FilteredResult<Product> GetAllProducts();
	}
}
