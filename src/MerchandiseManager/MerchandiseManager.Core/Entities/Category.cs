using MerchandiseManager.Core.Interfaces.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Core.Entities
{
	public class Category : IBaseEntity, IHasId<Guid>, IRecursiveEntity<Category>
	{
		public Guid Id { get; private set; }
		
		public string CategoryName { get; private set; }
		public string CategoryDescription { get; private set; }

		public Category Parent { get; private set; }
		public ICollection<Category> Children { get; private set; }
	}
}
