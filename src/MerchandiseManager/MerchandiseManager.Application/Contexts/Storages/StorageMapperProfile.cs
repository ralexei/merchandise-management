using AutoMapper;
using MerchandiseManager.Application.Contexts.Storages.Commands.AddNewStorage;
using MerchandiseManager.Application.Contexts.Storages.ViewModels;
using MerchandiseManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Application.Contexts.Storages
{
	public class StorageMapperProfile : Profile
	{
		public StorageMapperProfile()
		{
			CreateMap<AddNewStorageCommand, Storage>();
			CreateMap<Storage, StorageViewModel>();
		}
	}
}
