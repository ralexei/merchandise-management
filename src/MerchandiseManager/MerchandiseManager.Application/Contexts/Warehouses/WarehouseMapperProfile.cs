using AutoMapper;
using MerchandiseManager.Application.Contexts.Warehouses.Commands.AddNewStorage;
using MerchandiseManager.Application.Contexts.Warehouses.ViewModels;
using MerchandiseManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Application.Contexts.Warehouses
{
	public class WarehouseMapperProfile : Profile
	{
		public WarehouseMapperProfile()
		{
			CreateMap<AddNewWarehouseCommand, Warehouse>();
			CreateMap<Warehouse, WarehouseViewModel>();
		}
	}
}
