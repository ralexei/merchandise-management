using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Core.Interfaces.Entity
{
	public interface IHasId<T>
	{
		T Id { get; }
	}
}
