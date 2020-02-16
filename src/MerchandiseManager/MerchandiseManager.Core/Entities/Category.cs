using MerchandiseManager.Core.Interfaces.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Core.Entities
{
	public partial class Category : BaseEntity, IRecursiveEntity<Category>
	{		
		public string Name { get; private set; }
		public string Description { get; private set; }

		public Category Parent { get; private set; }
		public Guid? ParentId { get; private set; }

		public ICollection<Category> Children { get; private set; }

		public Category(string name, string description) : this(name)
		{
			Description = description;
		}

		public Category(string name)
		{
			if (string.IsNullOrEmpty(name))
				throw new ArgumentNullException(nameof(name));

			Name = name;
		}

		public Category IsChildOf(Guid parentId)
		{
			ParentId = parentId;

			return this;
		}
	}
}
