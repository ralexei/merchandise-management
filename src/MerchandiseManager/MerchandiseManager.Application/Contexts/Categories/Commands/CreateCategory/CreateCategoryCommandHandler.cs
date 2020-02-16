using AutoMapper;
using MediatR;
using MerchandiseManager.Application.Contexts.Categories.ViewModels;
using MerchandiseManager.Application.Interfaces.Persistence;
using MerchandiseManager.Core.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseManager.Application.Contexts.Categories.Commands.CreateCategory
{
	public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryViewModel>
	{
		private readonly IDbContext context;
		private readonly IMapper mapper;

		public CreateCategoryCommandHandler(IDbContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		public async Task<CategoryViewModel> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
		{
			var newCategory = new Category(request.Name, request.Description);

			if (request.ParentId.HasValue)
				newCategory.IsChildOf(request.ParentId.Value);

			await context.Categories.AddAsync(newCategory);
			await context.SaveChangesAsync(cancellationToken);

			return mapper.Map<CategoryViewModel>(newCategory);
		}
	}
}
