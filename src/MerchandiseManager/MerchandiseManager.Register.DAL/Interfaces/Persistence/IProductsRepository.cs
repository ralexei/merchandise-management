﻿using MerchandiseManager.Register.DAL.Interfaces;
using MerchandiseManager.Register.WPF.Persistence.Entities;
using System.Collections.Generic;

namespace MerchandiseManager.Register.WPF.Interfaces.Persistence
{
	public interface IProductsRepository : IGenericRepository<Product>
	{
		Product GetByBarcode(string barcode);
	}
}
