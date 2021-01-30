using DapperExtensions.Mapper;
using MerchandiseManager.Register.WPF.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Register.DAL.Mappers
{
	public class ProductMapper : ClassMapper<Product>
	{
		public ProductMapper()
		{
			Table("Products");
			Map(m => m.BarCodes).Ignore();
			AutoMap();
		}
	}
}
