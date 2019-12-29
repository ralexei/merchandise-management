using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseManager.Application.Interfaces.Validation.Persistence
{
	public interface IUserPersistenceValidator
	{
		bool UserWithUsernameExists(string username);
	}
}
