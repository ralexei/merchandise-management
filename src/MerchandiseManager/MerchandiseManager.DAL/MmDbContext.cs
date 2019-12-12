using MerchandiseManager.Application.Interfaces.Persistance;
using MerchandiseManager.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace MerchandiseManager.DAL
{
	public class MmDbContext : DbContext, IDbContext
	{
		public DbSet<User> Users { get; private set; }		public DbSet<Product> Products { get; private set; }		public DbSet<Category> Categories { get; private set; }		public DbSet<DeliveryNote> DeliveryNotes { get; private set; }		public DbSet<DeliveryNoteProduct> DeliveryNoteProducts { get; private set; }		public DbSet<LoginHistoryRecord> LoginHistory { get; private set; }		public DbSet<DiscountPackage> DiscountPackages { get; private set; }		public DbSet<SoldProduct> SoldProduct { get; private set; }		public DbSet<SoldCart> SoldCarts { get; private set; }		public DbSet<Storage> Storages { get; private set; }		public DbSet<StorageProduct> StorageProducts { get; private set; }

		public MmDbContext(DbContextOptions<MmDbContext> options) : base(options) { }
	}
}
