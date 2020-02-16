using AutoMapper;
using MerchandiseManager.Application.Contexts.SoldProducts.ViewModels;
using MerchandiseManager.Core.Entities;

namespace MerchandiseManager.Application.Contexts.SoldProducts
{
	public class SoldProductsMapperProfile : Profile
	{
		public SoldProductsMapperProfile()
		{
			CreateMap<SoldProduct, SoldProductViewModel>();
		}
	}
}
