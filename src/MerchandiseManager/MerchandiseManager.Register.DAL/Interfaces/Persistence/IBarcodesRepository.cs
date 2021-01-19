using MerchandiseManager.Register.DAL.Interfaces;
using MerchandiseManager.Register.WPF.Persistence.Entities;
using System.Collections.Generic;

namespace MerchandiseManager.Register.WPF.Interfaces.Persistence
{
	public interface IBarcodesRepository : IGenericRepository<BarCode>
	{
	}
}
