using MerchandiseManager.Application.Interfaces.Persistence;
using MerchandiseManager.Application.Interfaces.Validation.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MerchandiseManager.Application.Helpers.Validation.Persistence
{
	public class CategoryPersistenceValidator : ICategoryPersistenceValidator
	{
		private readonly IDbContext db;

		public CategoryPersistenceValidator(IDbContext db)
		{
			this.db = db;
		}

		public bool CategoryWithIdExists(Guid id)
		{
			return db.Categories.Any(a => a.Id == id);
		}
	}
}
