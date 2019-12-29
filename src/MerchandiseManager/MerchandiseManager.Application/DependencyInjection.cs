using AutoMapper;
using MediatR;
using MerchandiseManager.Application.Helpers.Validation.Persistence;
using MerchandiseManager.Application.Interfaces.Validation.Persistence;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MerchandiseManager.Application
{
	public static class DependencyInjection
	{
		public static void RegisterApplicationLayer(this IServiceCollection services)
		{
			var currentAssembly = typeof(DependencyInjection).Assembly;

			services.AddMediatR(currentAssembly);
			services.AddAutoMapper(currentAssembly);

			services.AddTransient<IUserPersistenceValidator, UserPersistenceValidator>();
			services.AddTransient<ICategoryPersistenceValidator, CategoryPersistenceValidator>();
			//Add validator and pipeline behaviours
		}
	}
}
