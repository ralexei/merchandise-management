using AutoMapper;
using MerchandiseManager.Application.Contexts.Products.Commands.AddNewProduct;
using MerchandiseManager.Application.Contexts.Products.ViewModels;
using MerchandiseManager.Core.Entities;
using System.Linq;

namespace MerchandiseManager.Application.Contexts.Products
{
	public class ProductsMapperProfile : Profile
	{
		public ProductsMapperProfile()
		{
			CreateMap<AddNewProductCommand, Product>();
			CreateMap<Product, ProductViewModel>()
				.ForMember(m => m.TotalCount, opt => opt.MapFrom(src => src.StorageProducts.Sum(s => s.ProductsAmount)));
		}
	}
}
