using AutoMapper;
using MerchandiseManager.Application.Contexts.Storages.ViewModels;
using MerchandiseManager.Core.Entities;

namespace MerchandiseManager.Application.Contexts.Storages
{
	public class StorageMapperProfile : Profile
	{
		public StorageMapperProfile()
		{
			CreateMap<Storage, StorageViewModel>();
		}
	}
}
