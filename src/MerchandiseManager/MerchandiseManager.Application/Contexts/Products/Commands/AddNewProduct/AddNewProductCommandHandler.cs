using AutoMapper;
using MediatR;
using MerchandiseManager.Application.Contexts.Products.ViewModels;
using MerchandiseManager.Application.Interfaces.Authentication;
using MerchandiseManager.Application.Interfaces.Persistence;
using MerchandiseManager.Core.Entities;
using System;
using System.Collections.Generic;
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

				var barcodes = new HashSet<string>(request.Barcodes);

				foreach (var barcode in barcodes)
					newProduct.BarCodes.Add(new BarCode(barcode));

				await db.Products.AddAsync(newProduct);
				await db.SaveChangesAsync(cancellationToken);

				var result = mapper.Map<ProductViewModel>(newProduct);
				
				return result;
			}
			catch (Exception ex)
			{
				throw;
			}
		}
	}
}
