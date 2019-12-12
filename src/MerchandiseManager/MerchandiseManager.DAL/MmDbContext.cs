﻿using MerchandiseManager.Application.Interfaces.Persistance;
using MerchandiseManager.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace MerchandiseManager.DAL
{
	public class MmDbContext : DbContext, IDbContext
	{
		public DbSet<User> Users { get; private set; }

		public MmDbContext(DbContextOptions<MmDbContext> options) : base(options) { }
	}
}