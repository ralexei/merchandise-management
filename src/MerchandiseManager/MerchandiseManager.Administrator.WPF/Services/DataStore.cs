using System;

namespace MerchandiseManager.Administrator.WPF.Services
{
	public class DataStore
	{
		public string AccessToken { get; set; }

		#region Singleton Related Properties
		private static readonly Lazy<DataStore> lazy = 
			new Lazy<DataStore>(() => new DataStore());

		public static DataStore Instance => lazy.Value;

		private DataStore()
		{
		}
		#endregion
	}
}
