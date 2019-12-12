
using System.Collections.Generic;

namespace MerchandiseManager.Core.Interfaces.Entity
{
	public interface IRecursiveEntity<T> where T : IBaseEntity
	{
		T Parent { get; }
		ICollection<T> Children { get; }
	}
}
