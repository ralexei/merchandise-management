using AutoMapper;
using MerchandiseManager.Application.Contexts.Categories.ViewModels;
using MerchandiseManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Application.Contexts.Categories
{
	public class CategoryMappingProfile : Profile
	{
		public CategoryMappingProfile()
		{
			CreateMap<Category, CategoryViewModel>();
			CreateMap<Category, CategoryFlatViewModel>();
			CreateMap<CategoryViewModel, CategoryFlatViewModel>();
		}
	}
}
