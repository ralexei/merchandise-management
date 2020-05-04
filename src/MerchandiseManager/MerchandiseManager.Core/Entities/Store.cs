namespace MerchandiseManager.Core.Entities
{
	public class Store : Storage
	{
		protected Store() { }

		public Store(string storageName, string storageDescription) : base(storageName, storageDescription) { }

		public Store(string storeName) : base(storeName) { }
	}
}
