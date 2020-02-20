using AutoMapper;
using MediatR;
using MerchandiseManager.Application.Contexts.Products.ViewModels;
using MerchandiseManager.Application.Interfaces.Persistence;
using MerchandiseManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseManager.Application.Contexts.Products.Commands.EditProduct
{
	public class EditProductCommandHandler : IRequestHandler<EditProductCommand, ProductViewModel>
	{
		private readonly IDbContext context;
		private readonly IMapper mapper;

		public EditProductCommandHandler(IDbContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		public async Task<ProductViewModel> Handle(EditProductCommand request, CancellationToken cancellationToken)
		{
			var productToUpdate = await context
				.Products
				.Include(i => i.BarCodes)
				.FirstOrDefaultAsync(f => f.Id == request.Id);

			mapper.Map<EditProductCommand, Product>(request, productToUpdate);

			UpdateBarcodes(productToUpdate, request.Barcodes);

			await context.SaveChangesAsync(cancellationToken);

			return mapper.Map<ProductViewModel>(productToUpdate);
		}

		private void UpdateBarcodes(Product product, string[] barcodes)
		{
			var selectedBarcodes = new HashSet<string>(barcodes);
			var productBarcodes = new HashSet<string>(product.BarCodes.Select(s => s.RawCode));

			foreach (var productBarcode in productBarcodes)
			{
				if (!selectedBarcodes.Contains(productBarcode))
				{
					var barcodeToRemove = product.BarCodes.FirstOrDefault(f => f.RawCode == productBarcode);

					context.Barcodes.Remove(barcodeToRemove);
				}
			}

			foreach (var selectedBarcode in selectedBarcodes)
			{
				if (!productBarcodes.Contains(selectedBarcode))
				{
					product.BarCodes.Add(new BarCode(selectedBarcode));
				}
			}
		}
	}
}
