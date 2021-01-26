using MerchandiseManager.Core.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace MerchandiseManager.Application.Contexts.Storages.ViewModels
{
	public class StorageViewModel
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		[JsonConverter( StringEnumConverter)]
		public StorageTypes StorageType { get; set; }
	}
}
