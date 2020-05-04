using System.Text;
using FluentValidation.AspNetCore;
using MerchandiseManager.Api.Utils;
using MerchandiseManager.Api.Utils.Auth;
using MerchandiseManager.Application;
using MerchandiseManager.Application.Contexts.Authorization.Commands.SignIn;
using MerchandiseManager.Application.Interfaces.Authentication;
using MerchandiseManager.Application.Interfaces.Persistence;
using MerchandiseManager.Application.Models.Config;
using MerchandiseManager.DAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace MerchandiseManager.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<IDbContext, MmDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

			// Bind AppSettings
			var appSettingsSection = Configuration.GetSection("AppSettings");
			services.Configure<AppSettings>(appSettingsSection);

			// Configure JwtAuth
			var appSettings = appSettingsSection.Get<AppSettings>();
			var key = Encoding.ASCII.GetBytes(appSettings.JwtSettings.Secret);


			services.AddCors();

			services.AddAuthentication(x =>
			{
				x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(x =>
			{
				x.RequireHttpsMetadata = false;
				x.SaveToken = true;
				x.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(key),
					ValidateIssuer = false,
					ValidateAudience = false
				};
			});

			services.AddHttpContextAccessor();
			services.AddControllers();

			services.RegisterApplicationLayer();

			services.AddTransient<IJwtHandler, JwtHandler>();
			services.AddTransient<ICurrentUser, CurrentUserProvider>();

			services
				.AddMvcCore(options => { options.EnableEndpointRouting = false; })
				.AddNewtonsoftJson()
				.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<SignInCommandValidator>());
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();
			app.UseCors(opt =>
			{
				opt.WithOrigins("http://116.203.19.248", "http://localhost:4200")
					.AllowAnyMethod()
					.AllowAnyHeader();
			});

			app.UseMiddleware<ExceptionHandlingMiddleware>();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
