using MerchandiseManager.Application.Interfaces.Persistance;
using MerchandiseManager.Application.Interfaces.Validation.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;

namespace MerchandiseManager.Application.Helpers.Validation.Persistence
{
	public class UserPersistenceValidator : IUserPersistenceValidator
	{
		private readonly IDbContext db;

		public UserPersistenceValidator(IDbContext db)
		{
			this.db = db;
		}

		public bool UserWithUsernameExists(string username)
		{
			return db.Users.Any(a => a.Username == username);
		}
	}
}
