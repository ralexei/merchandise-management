using MerchandiseManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseManager.Application.Interfaces.Persistence
{
	public interface IDbContext
	{
		DbSet<User> Users { get; }
		DbSet<Product> Products { get; }
		DbSet<Category> Categories { get; }
		DbSet<DeliveryNote> DeliveryNotes { get; }
		DbSet<DeliveryNoteProduct> DeliveryNoteProducts { get; }
		DbSet<LoginHistoryRecord> LoginHistory { get; }
		DbSet<DiscountPackage> DiscountPackages { get; }
		DbSet<SoldProduct> SoldProducts { get; }
		DbSet<SoldCart> SoldCarts { get; }
		DbSet<Storage> Storages { get; }
		DbSet<Store> Stores { get; }
		DbSet<StorageProduct> StorageProducts { get; }
		DbSet<UserStorage> UserStorages { get; }
		DbSet<BarCode> Barcodes { get; }

		DatabaseFacade Database { get; }

		int SaveChanges();
		Task<int> SaveChangesAsync(CancellationToken cancellationToken);

	}
}
