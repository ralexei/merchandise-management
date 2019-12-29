using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Application.Interfaces.Validation.Persistence
{
	public interface ICategoryPersistenceValidator
	{
		bool CategoryWithIdExists(Guid id);
	}
}
