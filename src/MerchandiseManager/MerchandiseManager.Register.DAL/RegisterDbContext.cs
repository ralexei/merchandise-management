using Dapper;
using MerchandiseManager.Register.DAL.TypeHandlers;
using MerchandiseManager.Register.WPF.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace MerchandiseManager.Register.DAL
{
	public class RegisterDbContext : DbContext
	{
		public DbSet<Product> Products { get; set; }
		public DbSet<BarCode> BarCodes { get; set; }

		private readonly string connectionString;

		public RegisterDbContext(string connectionString)
		{
			this.connectionString = connectionString;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			DapperExtensions.DapperExtensions.SqlDialect = new DapperExtensions.Sql.SqliteDialect();

			optionsBuilder.UseSqlite(connectionString);

			SqlMapper.AddTypeHandler(new GuidTypeHandler());
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder
				.Entity<Product>()
				.HasKey(k => k.Id);

			builder
				.Entity<BarCode>()
				.HasKey(k => k.Id);

			builder
				.Entity<Product>()
				.Property(p => p.BuyPrice)
				.HasColumnType("REAL");

			builder
				.Entity<Product>()
				.Property(p => p.RetailSellPrice)
				.HasColumnType("REAL");

			builder
				.Entity<Product>()
				.Property(p => p.WholesaleSellPrice)
				.HasColumnType("REAL");

			builder
				.Entity<Product>()
				.Property(p => p.TotalAmount)
				.HasColumnType("INTEGER");
		}
	}
}
