using AutoMapper;
using MerchandiseManager.Application.Contexts.StorageProducts.ViewModels;
using MerchandiseManager.Core.Entities;

namespace MerchandiseManager.Application.Contexts.StorageProducts
{
	public class StorageProductMapperProfile : Profile
	{
		public StorageProductMapperProfile()
		{
			CreateMap<StorageProduct, StorageProductViewModel>();
		}
	}
}
