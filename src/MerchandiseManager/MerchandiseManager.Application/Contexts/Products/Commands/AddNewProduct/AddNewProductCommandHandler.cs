using AutoMapper;
using MediatR;
using MerchandiseManager.Application.Interfaces.Persistance;
using MerchandiseManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseManager.Application.Contexts.Products.Commands.AddNewProduct
{
	public class AddNewProductCommandHandler : IRequestHandler<AddNewProductCommand, Unit>
	{
		private readonly IDbContext db;
		private readonly IMapper mapper;

		public AddNewProductCommandHandler(IDbContext db, IMapper mapper)
		{
			this.db = db;
			this.mapper = mapper;
		}

		public async Task<Unit> Handle(AddNewProductCommand request, CancellationToken cancellationToken)
		{
			var newProduct = mapper.Map<Product>(request);

			await db.Products.AddAsync(newProduct);
			await db.SaveChangesAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
