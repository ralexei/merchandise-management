using FluentValidation;
using System.Linq;

namespace MerchandiseManager.Application.Contexts.Storages.Commands.ReplenishStorage
{
	public class ReplenishStorageCommandValidator : AbstractValidator<ReplenishStorageCommand>
	{
		public ReplenishStorageCommandValidator()
		{
			RuleFor(r => r.Products)
				.NotEmpty()
				.Must((m) => m.All(a => a.Value > 0));
		}
	}
}
