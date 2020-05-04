using AutoMapper;
using MerchandiseManager.Application.Contexts.Stores.Commands.AddNewStore;
using MerchandiseManager.Core.Entities;

namespace MerchandiseManager.Application.Contexts.Warehouses
{
	public class StoreMapperProfile : Profile
	{
		public StoreMapperProfile()
		{
			CreateMap<AddNewStoreCommand, Store>();
		}
	}
}
