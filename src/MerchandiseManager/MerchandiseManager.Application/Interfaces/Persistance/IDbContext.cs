using MerchandiseManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseManager.Application.Interfaces.Persistance
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
		DbSet<SoldProduct> SoldProduct { get; }
		DbSet<SoldCart> SoldCarts { get; }
		DbSet<Storage> Storages { get; }
		DbSet<StorageProduct> StorageProducts { get; }

		int SaveChanges();
		Task<int> SaveChangesAsync(CancellationToken cancellationToken);
	}
}
