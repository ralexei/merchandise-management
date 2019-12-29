using MerchandiseManager.Core.Interfaces.Entity;
using MerchandiseManager.Utility.Crypto.Hashers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MerchandiseManager.Core.Entities
{
	public partial class User : BaseEntity 
	{
		public DateTime HireDate { get; private set; }
		public string FirstName { get; private set; }
		public string LastName { get; private set; }
		public string Username { get; private set; }
		public byte[] Password { get; private set; }

		public ICollection<LoginHistoryRecord> LoginHistory { get; private set; } = new List<LoginHistoryRecord>();
		public ICollection<SoldProduct> SoldProducts { get; private set; }

		public string GetFullName()
		{
			return FirstName + " " + LastName;
		}

		public User SetPassword(string password)
		{
			Password = Md5Hasher.GenerateBytes(password);

			return this;
		}

		public bool IsPasswordValid(string password)
		{
			return Enumerable.SequenceEqual(Password, Md5Hasher.GenerateBytes(password));
		}

		public void RecordLoginAction()
		{
			LoginHistory.Add(new LoginHistoryRecord());
		}
	}
}
