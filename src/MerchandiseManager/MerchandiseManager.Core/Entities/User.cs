using MerchandiseManager.Core.Interfaces.Entity;
using MerchandiseManager.Utility.Crypto.Hashers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MerchandiseManager.Core.Entities
{
	public partial class User : BaseEntity 
	{
		public DateTime? HireDate { get; private set; }
		public string FirstName { get; private set; }
		public string LastName { get; private set; }
		public string Username { get; private set; }
		public byte[] Password { get; private set; }

		public int BarcodeFriendlyId { get; set; }

		#region Navigation properties
		public ICollection<LoginHistoryRecord> LoginHistory { get; private set; } = new List<LoginHistoryRecord>();
		public ICollection<Product> Products { get; private set; } = new HashSet<Product>();
		public ICollection<SoldProduct> SoldProducts { get; private set; } = new List<SoldProduct>();
		public ICollection<Warehouse> Warehouses { get; private set; } = new List<Warehouse>();
		#endregion

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
