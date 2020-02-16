﻿// <auto-generated />
using System;
using MerchandiseManager.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MerchandiseManager.DAL.Migrations
{
    [DbContext(typeof(MmDbContext))]
    [Migration("20200214204937_CategoryNullable")]
    partial class CategoryNullable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MerchandiseManager.Core.Entities.BarCode", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("CreatedAt")
                        .HasColumnType("bigint");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RawCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("UpdatedAt")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("BarCode");
                });

            modelBuilder.Entity("MerchandiseManager.Core.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CreatedAt")
                        .HasColumnType("bigint");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long?>("UpdatedAt")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("MerchandiseManager.Core.Entities.DeliveryNote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("CreatedAt")
                        .HasColumnType("bigint");

                    b.Property<Guid>("DestinationStorageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SourceStorageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long?>("UpdatedAt")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("DestinationStorageId")
                        .IsUnique();

                    b.HasIndex("SourceStorageId")
                        .IsUnique()
                        .HasFilter("[SourceStorageId] IS NOT NULL");

                    b.ToTable("DeliveryNotes");
                });

            modelBuilder.Entity("MerchandiseManager.Core.Entities.DeliveryNoteProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<long>("CreatedAt")
                        .HasColumnType("bigint");

                    b.Property<Guid>("DeliveryNoteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long?>("UpdatedAt")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryNoteId");

                    b.HasIndex("ProductId");

                    b.ToTable("DeliveryNoteProducts");
                });

            modelBuilder.Entity("MerchandiseManager.Core.Entities.DiscountPackage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("CreatedAt")
                        .HasColumnType("bigint");

                    b.Property<decimal?>("DiscountSum")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("DiscountType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("MaxAmount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal?>("MinAmount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal?>("Percent")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long?>("UpdatedAt")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("DiscountPackages");
                });

            modelBuilder.Entity("MerchandiseManager.Core.Entities.LoginHistoryRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("CreatedAt")
                        .HasColumnType("bigint");

                    b.Property<long?>("UpdatedAt")
                        .HasColumnType("bigint");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("LoginHistory");
                });

            modelBuilder.Entity("MerchandiseManager.Core.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("BuyPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("CreatedAt")
                        .HasColumnType("bigint");

                    b.Property<string>("ProductDescription")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<decimal?>("RetailSellPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long?>("UpdatedAt")
                        .HasColumnType("bigint");

                    b.Property<decimal?>("WholesaleSellPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("MerchandiseManager.Core.Entities.SoldCart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Change")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("CreatedAt")
                        .HasColumnType("bigint");

                    b.Property<decimal>("ReceivedSum")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long?>("UpdatedAt")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("SoldCarts");
                });

            modelBuilder.Entity("MerchandiseManager.Core.Entities.SoldProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("BuyPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("BuyPriceCurrency")
                        .HasColumnType("nvarchar(12)")
                        .HasMaxLength(12);

                    b.Property<long>("CreatedAt")
                        .HasColumnType("bigint");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("SellPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("SellerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SoldCartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long?>("UpdatedAt")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SellerId");

                    b.HasIndex("SoldCartId");

                    b.ToTable("SoldProducts");
                });

            modelBuilder.Entity("MerchandiseManager.Core.Entities.Storage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("CreatedAt")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(32)")
                        .HasMaxLength(32);

                    b.Property<long?>("UpdatedAt")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Storages");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Storage");
                });

            modelBuilder.Entity("MerchandiseManager.Core.Entities.StorageProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("CreatedAt")
                        .HasColumnType("bigint");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ProductsAmount")
                        .HasColumnType("int");

                    b.Property<Guid>("StorageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long?>("UpdatedAt")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("StorageId");

                    b.ToTable("StorageProducts");
                });

            modelBuilder.Entity("MerchandiseManager.Core.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("CreatedAt")
                        .HasColumnType("bigint");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<byte[]>("Password")
                        .HasColumnType("varbinary(max)");

                    b.Property<long?>("UpdatedAt")
                        .HasColumnType("bigint");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MerchandiseManager.Core.Entities.UserStorage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("CreatedAt")
                        .HasColumnType("bigint");

                    b.Property<Guid>("StorageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long?>("UpdatedAt")
                        .HasColumnType("bigint");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("StorageId");

                    b.HasIndex("UserId");

                    b.ToTable("UserStorages");
                });

            modelBuilder.Entity("MerchandiseManager.Core.Entities.Store", b =>
                {
                    b.HasBaseType("MerchandiseManager.Core.Entities.Storage");

                    b.HasDiscriminator().HasValue("Store");
                });

            modelBuilder.Entity("MerchandiseManager.Core.Entities.BarCode", b =>
                {
                    b.HasOne("MerchandiseManager.Core.Entities.Product", "Product")
                        .WithMany("BarCodes")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MerchandiseManager.Core.Entities.Category", b =>
                {
                    b.HasOne("MerchandiseManager.Core.Entities.Category", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("MerchandiseManager.Core.Entities.DeliveryNote", b =>
                {
                    b.HasOne("MerchandiseManager.Core.Entities.Storage", "DestinationStorage")
                        .WithOne()
                        .HasForeignKey("MerchandiseManager.Core.Entities.DeliveryNote", "DestinationStorageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MerchandiseManager.Core.Entities.Storage", "SourceStorage")
                        .WithOne()
                        .HasForeignKey("MerchandiseManager.Core.Entities.DeliveryNote", "SourceStorageId");
                });

            modelBuilder.Entity("MerchandiseManager.Core.Entities.DeliveryNoteProduct", b =>
                {
                    b.HasOne("MerchandiseManager.Core.Entities.DeliveryNote", "DeliveryNote")
                        .WithMany()
                        .HasForeignKey("DeliveryNoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MerchandiseManager.Core.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MerchandiseManager.Core.Entities.DiscountPackage", b =>
                {
                    b.HasOne("MerchandiseManager.Core.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("MerchandiseManager.Core.Entities.LoginHistoryRecord", b =>
                {
                    b.HasOne("MerchandiseManager.Core.Entities.User", "User")
                        .WithMany("LoginHistory")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MerchandiseManager.Core.Entities.Product", b =>
                {
                    b.HasOne("MerchandiseManager.Core.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("MerchandiseManager.Core.Entities.SoldProduct", b =>
                {
                    b.HasOne("MerchandiseManager.Core.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MerchandiseManager.Core.Entities.User", "Seller")
                        .WithMany("SoldProducts")
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MerchandiseManager.Core.Entities.SoldCart", null)
                        .WithMany("SoldProducts")
                        .HasForeignKey("SoldCartId");
                });

            modelBuilder.Entity("MerchandiseManager.Core.Entities.StorageProduct", b =>
                {
                    b.HasOne("MerchandiseManager.Core.Entities.Product", "Product")
                        .WithMany("StorageProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MerchandiseManager.Core.Entities.Storage", "Storage")
                        .WithMany("StorageProducts")
                        .HasForeignKey("StorageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MerchandiseManager.Core.Entities.UserStorage", b =>
                {
                    b.HasOne("MerchandiseManager.Core.Entities.Storage", "Storage")
                        .WithMany("UserStorages")
                        .HasForeignKey("StorageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MerchandiseManager.Core.Entities.User", "User")
                        .WithMany("UserStorages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
