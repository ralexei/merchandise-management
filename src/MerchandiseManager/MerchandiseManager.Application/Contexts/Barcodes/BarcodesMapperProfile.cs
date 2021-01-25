using AutoMapper;
using MerchandiseManager.Application.Contexts.Barcodes.ViewModels;
using MerchandiseManager.Core.Entities;

namespace MerchandiseManager.Application.Contexts.Barcodes
{
	public class BarcodesMapperProfile : Profile
	{
		public BarcodesMapperProfile()
		{
			CreateMap<BarCode, BarcodeViewModel>();
		}
	}
}
