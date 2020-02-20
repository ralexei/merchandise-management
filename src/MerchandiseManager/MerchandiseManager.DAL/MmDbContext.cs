using MerchandiseManager.Application.Interfaces.Authentication;
using MerchandiseManager.Application.Interfaces.Persistence;
using MerchandiseManager.Core.Entities;
using MerchandiseManager.Core.Interfaces.Entity;
using MerchandiseManager.DAL.EntityConfigurations;
using MerchandiseManager.Utility.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseManager.DAL
{
	public class MmDbContext : DbContext, IDbContext
	{
		public DbSet<User> Users { get; private set; }		public DbSet<Product> Products { get; private set; }		public DbSet<Category> Categories { get; private set; }		public DbSet<DeliveryNote> DeliveryNotes { get; private set; }		public DbSet<DeliveryNoteProduct> DeliveryNoteProducts { get; private set; }		public DbSet<LoginHistoryRecord> LoginHistory { get; private set; }		public DbSet<DiscountPackage> DiscountPackages { get; private set; }		public DbSet<SoldProduct> SoldProducts { get; private set; }		public DbSet<SoldCart> SoldCarts { get; private set; }		public DbSet<Storage> Storages { get; private set; }		public DbSet<Store> Stores { get; private set; }		public DbSet<StorageProduct> StorageProducts { get; private set; }
		public DbSet<UserStorage> UserStorages { get; private set; }
		public DbSet<BarCode> Barcodes { get; private set; }

		private readonly ICurrentUser currentUser;

		public MmDbContext(DbContextOptions<MmDbContext> options, ICurrentUser currentUser) : base(options)
		{
			this.currentUser = currentUser;
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			//builder.ApplyConfiguration(new CategoryConfiguration());

			var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
				.Where(type => !string.IsNullOrEmpty(type.Namespace))
				.Where(type => type.BaseType != null && !type.IsGenericType
													 && type.BaseType.IsGenericType
													 && (type.BaseType.GetGenericTypeDefinition() == typeof(RecursiveEntityConfiguration<>)
														|| type.BaseType.GetGenericTypeDefinition() == typeof(BaseEntityConfiguration<>)));

			foreach (var type in typesToRegister)
			{
				dynamic configurationInstance = Activator.CreateInstance(type);

				builder.ApplyConfiguration(configurationInstance);
			}
		}

		public override int SaveChanges()
		{
			Audit();
			return base.SaveChanges();
		}

		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			Audit();
			return base.SaveChangesAsync(cancellationToken);
		}

		private void ApplyGlobalFilters(ModelBuilder builder)
		{
			builder.Entity<Product>()
				.HasQueryFilter(f => f.UserId == currentUser.Id);
		}

		private void Audit()
		{
			ProcessDates();
		}

		private void ProcessDates()
		{
			var entries = ChangeTracker
				.Entries()
				.Where(e => e.Entity is BaseEntity && (
						e.State == EntityState.Added
						|| e.State == EntityState.Modified));

			foreach (var entityEntry in entries)
			{
				if (entityEntry.State != EntityState.Added)
					((BaseEntity)entityEntry.Entity).Updated();

				if (entityEntry.State == EntityState.Added)
				{
					((BaseEntity)entityEntry.Entity).Created();
				}
			}
		}
	}
}
