using DapperExtensions.Mapper;
using MerchandiseManager.Register.WPF.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Register.DAL.Mappers
{
	public class BarcodeMapper : ClassMapper<BarCode>
	{
		public BarcodeMapper()
		{
			Table("Barcodes");
			//Map(m => m).Ignore();
			AutoMap();
		}
	}
}
