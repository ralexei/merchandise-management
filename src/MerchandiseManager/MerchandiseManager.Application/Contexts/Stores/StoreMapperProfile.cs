using AutoMapper;
using MerchandiseManager.Application.Contexts.Stores.Commands.AddNewStore;
using MerchandiseManager.Application.Contexts.Stores.ViewModels;
using MerchandiseManager.Core.Entities;

namespace MerchandiseManager.Application.Contexts.Warehouses
{
	public class StoreMapperProfile : Profile
	{
		public StoreMapperProfile()
		{
			CreateMap<Store, StoreViewModel>();
			CreateMap<AddNewStoreCommand, Store>();
		}
	}
}
