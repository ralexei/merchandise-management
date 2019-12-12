using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Core.Interfaces.Entity
{
	public interface IHasDate
	{
		DateTime CreationTime { get; }
		DateTime? UpdateTime { get; }
	}
}
