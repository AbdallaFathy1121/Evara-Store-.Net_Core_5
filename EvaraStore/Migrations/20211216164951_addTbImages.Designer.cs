﻿// <auto-generated />
using System;
using EvaraStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EvaraStore.Migrations
{
    [DbContext(typeof(EvaraStoreContext))]
    [Migration("20211216164951_addTbImages")]
    partial class addTbImages
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Arabic_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EvaraStore.Models.TbCategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CategoryId");

                    b.ToTable("TbCategory");
                });

            modelBuilder.Entity("EvaraStore.Models.TbImages", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.HasKey("ImageId");

                    b.HasIndex("ItemId");

                    b.ToTable("TbImages");
                });

            modelBuilder.Entity("EvaraStore.Models.TbItem", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Discount")
                        .HasColumnType("int");

                    b.Property<string>("ItemName")
                        .HasMaxLength(200)
                        .HasColumnType("nchar(200)")
                        .IsFixedLength(true);

                    b.Property<decimal?>("OldPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("Qty")
                        .HasColumnType("int");

                    b.Property<decimal>("SalesPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<int>("SubCategoryId")
                        .HasColumnType("int");

                    b.HasKey("ItemId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("TbItem");
                });

            modelBuilder.Entity("EvaraStore.Models.TbItemSize", b =>
                {
                    b.Property<int>("ItemSizeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("SizeId")
                        .HasColumnType("int");

                    b.HasKey("ItemSizeId");

                    b.HasIndex("ItemId");

                    b.HasIndex("SizeId");

                    b.ToTable("TbItemSize");
                });

            modelBuilder.Entity("EvaraStore.Models.TbSize", b =>
                {
                    b.Property<int>("SizeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SizeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("SizeId");

                    b.ToTable("TbSize");
                });

            modelBuilder.Entity("EvaraStore.Models.TbSubCategory", b =>
                {
                    b.Property<int>("SubCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SubCategoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("SubCategoryId");

                    b.ToTable("TbSubCategory");
                });

            modelBuilder.Entity("EvaraStore.Models.TbImages", b =>
                {
                    b.HasOne("EvaraStore.Models.TbItem", "Item")
                        .WithMany("TbImages")
                        .HasForeignKey("ItemId")
                        .HasConstraintName("FK_TbImages_TbItem")
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("EvaraStore.Models.TbItem", b =>
                {
                    b.HasOne("EvaraStore.Models.TbCategory", "Category")
                        .WithMany("TbItems")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_TbItem_TbCategory")
                        .IsRequired();

                    b.HasOne("EvaraStore.Models.TbSubCategory", "SubCategory")
                        .WithMany("TbItems")
                        .HasForeignKey("SubCategoryId")
                        .HasConstraintName("FK_TbItem_TbSubCategory")
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("EvaraStore.Models.TbItemSize", b =>
                {
                    b.HasOne("EvaraStore.Models.TbItem", "Item")
                        .WithMany("TbItemSizes")
                        .HasForeignKey("ItemId")
                        .HasConstraintName("FK_TbItemSize_TbItem")
                        .IsRequired();

                    b.HasOne("EvaraStore.Models.TbSize", "Size")
                        .WithMany("TbItemSizes")
                        .HasForeignKey("SizeId")
                        .HasConstraintName("FK_TbItemSize_TbSize")
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("EvaraStore.Models.TbCategory", b =>
                {
                    b.Navigation("TbItems");
                });

            modelBuilder.Entity("EvaraStore.Models.TbItem", b =>
                {
                    b.Navigation("TbImages");

                    b.Navigation("TbItemSizes");
                });

            modelBuilder.Entity("EvaraStore.Models.TbSize", b =>
                {
                    b.Navigation("TbItemSizes");
                });

            modelBuilder.Entity("EvaraStore.Models.TbSubCategory", b =>
                {
                    b.Navigation("TbItems");
                });
#pragma warning restore 612, 618
        }
    }
}
