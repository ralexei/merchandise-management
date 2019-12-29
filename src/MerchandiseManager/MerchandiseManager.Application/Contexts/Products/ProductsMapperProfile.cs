using AutoMapper;
using MerchandiseManager.Application.Contexts.Products.Commands.AddNewProduct;
using MerchandiseManager.Application.Contexts.Products.ViewModels;
using MerchandiseManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Application.Contexts.Products
{
	public class ProductsMapperProfile : Profile
	{
		public ProductsMapperProfile()
		{
			CreateMap<AddNewProductCommand, Product>();
			CreateMap<Product, ProductViewModel>();
		}
	}
}
