using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GreeenGarden.Data.Entities;

public partial class GreenGardenDbContext : DbContext
{
    public GreenGardenDbContext()
    {
    }

    public GreenGardenDbContext(DbContextOptions<GreenGardenDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<CartDetail> CartDetails { get; set; }

    public virtual DbSet<Category> Categorys { get; set; }

    public virtual DbSet<CategoryDetail> CategoryDetails { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<District> Districts { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<FeedbackImage> FeedbackImages { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductItem> ProductItems { get; set; }

    public virtual DbSet<ProductItemImage> ProductItemImages { get; set; }

    public virtual DbSet<ProductSize> ProductSizes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Size> Sizes { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Voucher> Vouchers { get; set; }

    public virtual DbSet<Ward> Wards { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-8PA8D34\\SQLEXPRESS;Initial Catalog=GreenGardenDB;Integrated Security=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.Property(e => e.AccountId).ValueGeneratedNever();

            entity.HasOne(d => d.Role).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_Accounts_Roles");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.Property(e => e.CartId).ValueGeneratedNever();

            entity.HasOne(d => d.Customer).WithMany(p => p.Carts)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Carts_Customers");
        });

        modelBuilder.Entity<CartDetail>(entity =>
        {
            entity.Property(e => e.CartDetailId).ValueGeneratedNever();

            entity.HasOne(d => d.Cart).WithMany(p => p.CartDetails)
                .HasForeignKey(d => d.CartId)
                .HasConstraintName("FK_CartDetails_Carts");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.CategoryId).ValueGeneratedNever();

            entity.HasOne(d => d.CreateByNavigation).WithMany(p => p.Categories)
                .HasForeignKey(d => d.CreateBy)
                .HasConstraintName("FK_Categorys_Accounts");

            entity.HasOne(d => d.Image).WithMany(p => p.Categories)
                .HasForeignKey(d => d.ImageId)
                .HasConstraintName("FK_Categorys_Images");
        });

        modelBuilder.Entity<CategoryDetail>(entity =>
        {
            entity.Property(e => e.CategoryDetailId).ValueGeneratedNever();

            entity.HasOne(d => d.Category).WithMany(p => p.CategoryDetails)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_CategoryDetails_Categorys");

            entity.HasOne(d => d.Image).WithMany(p => p.CategoryDetails)
                .HasForeignKey(d => d.ImageId)
                .HasConstraintName("FK_CategoryDetails_Images");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.CustomerId).ValueGeneratedNever();
        });

        modelBuilder.Entity<District>(entity =>
        {
            entity.Property(e => e.DistrictId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.Property(e => e.FeedbackId).ValueGeneratedNever();

            entity.HasOne(d => d.CreateByNavigation).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.CreateBy)
                .HasConstraintName("FK_Feedbacks_Customers");

            entity.HasOne(d => d.ProductItem).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.ProductItemId)
                .HasConstraintName("FK_Feedbacks_ProductItems");
        });

        modelBuilder.Entity<FeedbackImage>(entity =>
        {
            entity.Property(e => e.FeedbackImageId).ValueGeneratedNever();

            entity.HasOne(d => d.Feedback).WithMany(p => p.FeedbackImages)
                .HasForeignKey(d => d.FeedbackId)
                .HasConstraintName("FK_FeedbackImages_Feedbacks");

            entity.HasOne(d => d.Image).WithMany(p => p.FeedbackImages)
                .HasForeignKey(d => d.ImageId)
                .HasConstraintName("FK_FeedbackImages_Images");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.Property(e => e.ImageId).ValueGeneratedNever();
            entity.Property(e => e.ImageUrl).HasColumnName("ImageURL");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.OrderId).ValueGeneratedNever();

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Orders_Customers");

            entity.HasOne(d => d.Voucher).WithMany(p => p.Orders)
                .HasForeignKey(d => d.VoucherId)
                .HasConstraintName("FK_Orders_Vouchers");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.Property(e => e.OrderDetailId).ValueGeneratedNever();

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_OrderDetails_Orders");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.ProductId).ValueGeneratedNever();

            entity.HasOne(d => d.CategoryDetail).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryDetailId)
                .HasConstraintName("FK_Products_CategoryDetails");

            entity.HasOne(d => d.Service).WithMany(p => p.Products)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK_Products_Services");
        });

        modelBuilder.Entity<ProductItem>(entity =>
        {
            entity.Property(e => e.ProductItemId).ValueGeneratedNever();
        });

        modelBuilder.Entity<ProductItemImage>(entity =>
        {
            entity.Property(e => e.ProductItemImageId).ValueGeneratedNever();

            entity.HasOne(d => d.Image).WithMany(p => p.ProductItemImages)
                .HasForeignKey(d => d.ImageId)
                .HasConstraintName("FK_ProductItemImages_Images");

            entity.HasOne(d => d.ProductItem).WithMany(p => p.ProductItemImages)
                .HasForeignKey(d => d.ProductItemId)
                .HasConstraintName("FK_ProductItemImages_ProductItems");
        });

        modelBuilder.Entity<ProductSize>(entity =>
        {
            entity.Property(e => e.ProductSizeId).ValueGeneratedNever();

            entity.HasOne(d => d.Product).WithMany(p => p.ProductSizes)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_ProductSizes_Products");

            entity.HasOne(d => d.Size).WithMany(p => p.ProductSizes)
                .HasForeignKey(d => d.SizeId)
                .HasConstraintName("FK_ProductSizes_Sizes");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.RoleId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.Property(e => e.ServiceId).ValueGeneratedNever();

            entity.HasOne(d => d.CreateByNavigation).WithMany(p => p.Services)
                .HasForeignKey(d => d.CreateBy)
                .HasConstraintName("FK_Services_Accounts");
        });

        modelBuilder.Entity<Size>(entity =>
        {
            entity.Property(e => e.SizeId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.Property(e => e.StatusId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Voucher>(entity =>
        {
            entity.Property(e => e.VoucherId).ValueGeneratedNever();

            entity.HasOne(d => d.CreateByNavigation).WithMany(p => p.Vouchers)
                .HasForeignKey(d => d.CreateBy)
                .HasConstraintName("FK_Vouchers_Accounts");

            entity.HasOne(d => d.Customer).WithMany(p => p.Vouchers)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Vouchers_Customers");
        });

        modelBuilder.Entity<Ward>(entity =>
        {
            entity.Property(e => e.WardId).ValueGeneratedNever();

            entity.HasOne(d => d.District).WithMany(p => p.Wards)
                .HasForeignKey(d => d.DistrictId)
                .HasConstraintName("FK_Wards_Districts");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
