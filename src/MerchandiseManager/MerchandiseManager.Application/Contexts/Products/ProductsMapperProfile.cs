using AutoMapper;
using MerchandiseManager.Application.Contexts.Products.Commands.AddNewProduct;
using MerchandiseManager.Application.Contexts.Products.Commands.EditProduct;
using MerchandiseManager.Application.Contexts.Products.ViewModels;
using MerchandiseManager.Core.Entities;
using System.Linq;

namespace MerchandiseManager.Application.Contexts.Products
{
	public class ProductsMapperProfile : Profile
	{
		public ProductsMapperProfile()
		{
			CreateMap<AddNewProductCommand, Product>()
				.ForMember(m => m.BarCodes, opt => opt.Ignore());
			CreateMap<EditProductCommand, Product>()
				.ForMember(m => m.Id, opt => opt.Ignore())
				.ForMember(m => m.BarCodes, opt => opt.Ignore());

			CreateMap<Product, ProductViewModel>()
				.ForMember(m => m.TotalAmount, opt => opt.MapFrom(src => src.StorageProducts.Sum(s => s.ProductsAmount)))
				.ForMember(m => m.Barcodes, opt => opt.MapFrom(src => src.BarCodes.Select(s => s.RawCode)));
		}
	}
}
