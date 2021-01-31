using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Application.Contexts.StorageProducts.Queries.GetUserProductsByStorageId
{
	public class GetUserProductsByStorageIdQueryValidator : AbstractValidator<GetUserProductsByStorageIdQuery>
	{
		public GetUserProductsByStorageIdQueryValidator()
		{
			RuleFor(r => r.StorageId)
				.NotNull();
		}
	}
}
