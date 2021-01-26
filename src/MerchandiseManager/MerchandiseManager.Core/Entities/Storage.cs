using MerchandiseManager.Core.Enums;
using MerchandiseManager.Core.Interfaces.Entity;
using MerchandiseManager.Utility.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MerchandiseManager.Core.Entities
{
	public partial class Storage : BaseEntity 
	{
		public string Name { get; private set; }
		public string Description { get; private set; }

		public StorageTypes StorageType { get; private set; }

		#region Navigation properties
		public ICollection<StorageProduct> StorageProducts { get; private set; } = new List<StorageProduct>();
		public ICollection<UserStorage> UserStorages { get; private set; } = new List<UserStorage>();
		#endregion

		protected Storage() { }

		public Storage(string storageName, string storageDescription) : this(storageName)
		{
			Description = storageDescription;
		}

		public Storage(string storageName)
		{
			if (storageName.IsNullOrEmpty())
				throw new ArgumentException("is null or empty", nameof(storageName));

			Name = storageName;
		}

		public Storage Replenish(Dictionary<Guid, int> products)
		{
			// If storage has records of some products - increase their amount
			var existingProducts = StorageProducts
				.Where(w => products.Keys.ToList().Contains(w.ProductId));

			foreach (var existingProduct in existingProducts)
				existingProduct.IncreaseQuantityOfGoods(products[existingProduct.ProductId]);

			// Add new products
			var productsToAdd = products
				.Where(w => !existingProducts.Any(a => a.ProductId == w.Key))
				.Select(s => new StorageProduct(s.Key, s.Value, Id));

			foreach (var productToAdd in productsToAdd)
				StorageProducts.Add(productToAdd);

			return this;
		}
	}
}
