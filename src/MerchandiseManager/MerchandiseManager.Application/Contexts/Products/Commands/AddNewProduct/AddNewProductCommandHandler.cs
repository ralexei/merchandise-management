using AutoMapper;
using MediatR;
using MerchandiseManager.Application.Contexts.Products.ViewModels;
using MerchandiseManager.Application.Helpers;
using MerchandiseManager.Application.Interfaces.Authentication;
using MerchandiseManager.Application.Interfaces.Persistence;
using MerchandiseManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseManager.Application.Contexts.Products.Commands.AddNewProduct
{
	public class AddNewProductCommandHandler : IRequestHandler<AddNewProductCommand, ProductViewModel>
	{
		private readonly IDbContext db;
		private readonly IMapper mapper;
		private readonly ICurrentUser currentUser;

		public AddNewProductCommandHandler(
			IDbContext db,
			IMapper mapper,
			ICurrentUser currentUser)
		{
			this.db = db;
			this.mapper = mapper;
			this.currentUser = currentUser;
		}

		public async Task<ProductViewModel> Handle(AddNewProductCommand request, CancellationToken cancellationToken)
		{
			try
			{
				var newProduct = mapper.Map<Product>(request);

				newProduct.AssignToUser(currentUser.Id);

				if (request.Barcodes?.Count() > 0)
				{
					var barcodes = new HashSet<string>(request.Barcodes);

					foreach (var barcode in barcodes)
						newProduct.BarCodes.Add(new BarCode(barcode));
				}
				await db.Products.AddAsync(newProduct);
				await db.SaveChangesAsync(cancellationToken);

				await db.Entry(newProduct).Reference(r => r.Category).LoadAsync();
				await db.Entry(newProduct).Reference(r => r.User).LoadAsync();

				newProduct.BarCodes.Add(new BarCode(BarcodeGenerator.Generate(newProduct.Category.BarcodeFriendlyId, newProduct.BarcodeFriendlyId, newProduct.User.BarcodeFriendlyId)));

				await db.SaveChangesAsync(cancellationToken);

				return mapper.Map<ProductViewModel>(newProduct);
			}
			catch (Exception ex)
			{
				throw;
			}
		}
	}
}
