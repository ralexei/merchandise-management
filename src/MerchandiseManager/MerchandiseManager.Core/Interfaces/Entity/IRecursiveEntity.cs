
using System;
using System.Collections.Generic;

namespace MerchandiseManager.Core.Interfaces.Entity
{
	public interface IRecursiveEntity<T> where T : BaseEntity
	{
		T Parent { get; }
		Guid? ParentId { get; }

		ICollection<T> Children { get; }
	}
}
