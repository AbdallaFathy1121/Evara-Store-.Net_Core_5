using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EvaraStore.Models
{
    public partial class EvaraStoreContext : IdentityDbContext<AppUser>
    {
        public EvaraStoreContext()
        {
        }

        public EvaraStoreContext(DbContextOptions<EvaraStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbCategory> TbCategories { get; set; }
        public virtual DbSet<TbItem> TbItems { get; set; }
        public virtual DbSet<TbSubCategory> TbSubCategories { get; set; }
        public virtual DbSet<TbImages> TbImages { get; set; }
        public virtual DbSet<TbBilling> TbBilling { get; set; }
        public virtual DbSet<TbRate> TbRate { get; set; }
        public virtual DbSet<TbOrder> TbOrder { get; set; }
        public virtual DbSet<TbOrderItems> TbOrderItems { get; set; }
        public virtual DbSet<TbSetting> TbSetting { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Relational:Collation", "Arabic_CI_AS");

            modelBuilder.Entity<TbCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.ToTable("TbCategory");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.ImageName).IsRequired();

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TbItem>(entity =>
            {
                entity.HasKey(e => e.ItemId);

                entity.ToTable("TbItem");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.ItemName)
                    .HasMaxLength(200)
                    .IsFixedLength(true);

                entity.Property(e => e.OldPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SalesPrice).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TbItems)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbItem_TbCategory");

                entity.HasOne(d => d.SubCategory)
                    .WithMany(p => p.TbItems)
                    .HasForeignKey(d => d.SubCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbItem_TbSubCategory");
            });

            modelBuilder.Entity<TbImages>(entity =>
            {
                entity.HasKey(e => e.ImageId);

                entity.ToTable("TbImages");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.TbImages)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbImages_TbItem");
            });

            modelBuilder.Entity<TbSubCategory>(entity =>
            {
                entity.HasKey(e => e.SubCategoryId);

                entity.ToTable("TbSubCategory");
                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.SubCategoryName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TbSubCategories)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbSubCategory_TbCategory");
            });

            modelBuilder.Entity<TbBilling>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("TbBilling");

                entity.Property(e => e.FullName);
                entity.Property(e => e.Phone1);
                entity.Property(e => e.Phone2);
                entity.Property(e => e.Country);
                entity.Property(e => e.City);
                entity.Property(e => e.Address);
                entity.Property(e => e.UserId);
                entity.Property(e => e.UserName);
                entity.Property(e => e.UserEmail);

            });

            modelBuilder.Entity<TbRate>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("TbRate");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");
                entity.Property(e => e.Star);
                entity.Property(e => e.Comment);
                entity.Property(e => e.UserId);
                entity.Property(e => e.UserName);

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.TbRate)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbItem_TbRate");
            });

            modelBuilder.Entity<TbOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.ToTable("TbOrder");

                entity.Property(e => e.Date).HasColumnType("datetime");
                entity.Property(e => e.Status);
                entity.Property(e => e.Total);
                entity.Property(e => e.SerialNumber);

                entity.HasOne(d => d.Billing)
                    .WithMany(p => p.TbOrder)
                    .HasForeignKey(d => d.BillingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbBilling_TbOrder");
            });

            modelBuilder.Entity<TbOrderItems>(entity =>
            {
                entity.HasKey(e => e.OrderItemId);

                entity.ToTable("TbOrderItems");

                entity.Property(e => e.ImageName);
                entity.Property(e => e.ItemName);
                entity.Property(e => e.Qty);
                entity.Property(e => e.Price);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.TbOrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbOrder_TbOrderItems");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.TbOrderItems)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbItem_TbOrderItems");
            });

            modelBuilder.Entity<TbSetting>(entity =>
            {
                entity.HasKey(e => e.SettingId);

                entity.ToTable("TbSetting");

                entity.Property(e => e.MainPhone);
                entity.Property(e => e.HotLinePhone);
                entity.Property(e => e.Facebook);
                entity.Property(e => e.Twitter);
                entity.Property(e => e.Pinterest);
                entity.Property(e => e.YouTube);
                entity.Property(e => e.Insatgram);
                entity.Property(e => e.Address);

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
