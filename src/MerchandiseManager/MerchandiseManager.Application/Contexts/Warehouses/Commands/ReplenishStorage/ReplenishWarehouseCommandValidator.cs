using FluentValidation;
using System.Linq;

namespace MerchandiseManager.Application.Contexts.Warehouses.Commands.ReplenishStorage
{
	public class ReplenishWarehouseCommandValidator : AbstractValidator<ReplenishWarehouseCommand>
	{
		public ReplenishWarehouseCommandValidator()
		{
			RuleFor(r => r.Products)
				.NotEmpty()
				.Must((m) => m.All(a => a.Value > 0));
		}
	}
}
