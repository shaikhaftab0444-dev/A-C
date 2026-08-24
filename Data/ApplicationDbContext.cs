using BrandsStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BrandsStore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Existing DbSets
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }

        // Product Variant DbSets
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }

        // ✅ NEW: Offers (hero slides on home page)
        public DbSet<Offer> Offers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ================================================
            // PRODUCT CONFIGURATION
            // ================================================
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // ================================================
            // ORDER CONFIGURATION
            // ================================================
            modelBuilder.Entity<Order>()
                .Property(o => o.TotalAmount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // ================================================
            // ORDER DETAIL CONFIGURATION
            // ================================================
            modelBuilder.Entity<OrderDetail>()
                .Property(od => od.UnitPrice)
                .HasColumnType("decimal(18,2)");

            // ================================================
            // WISHLIST CONFIGURATION
            // ================================================
            modelBuilder.Entity<Wishlist>()
                .HasOne(w => w.User)
                .WithMany(u => u.Wishlists)
                .HasForeignKey(w => w.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Wishlist>()
                .HasOne(w => w.Product)
                .WithMany()
                .HasForeignKey(w => w.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Wishlist>()
                .HasIndex(w => new { w.UserId, w.ProductId })
                .IsUnique();

            // ================================================
            // SIZE CONFIGURATION
            // ================================================
            modelBuilder.Entity<Size>()
                .HasOne(s => s.Category)
                .WithMany(c => c.Sizes)
                .HasForeignKey(s => s.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Size>()
                .HasIndex(s => s.CategoryId)
                .HasDatabaseName("IX_Sizes_CategoryId");

            // ================================================
            // COLOR CONFIGURATION
            // ================================================
            modelBuilder.Entity<Color>()
                .HasOne(c => c.Category)
                .WithMany(cat => cat.Colors)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Color>()
                .HasIndex(c => c.CategoryId)
                .HasDatabaseName("IX_Colors_CategoryId");

            // ================================================
            // PRODUCT VARIANT CONFIGURATION
            // ================================================
            modelBuilder.Entity<ProductVariant>()
                .Property(pv => pv.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<ProductVariant>()
                .HasOne(pv => pv.Product)
                .WithMany(p => p.ProductVariants)
                .HasForeignKey(pv => pv.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductVariant>()
                .HasOne(pv => pv.Size)
                .WithMany(s => s.ProductVariants)
                .HasForeignKey(pv => pv.SizeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductVariant>()
                .HasOne(pv => pv.Color)
                .WithMany(c => c.ProductVariants)
                .HasForeignKey(pv => pv.ColorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductVariant>()
                .HasIndex(pv => pv.ProductId)
                .HasDatabaseName("IX_ProductVariants_ProductId");

            modelBuilder.Entity<ProductVariant>()
                .HasIndex(pv => pv.SizeId)
                .HasDatabaseName("IX_ProductVariants_SizeId");

            modelBuilder.Entity<ProductVariant>()
                .HasIndex(pv => pv.ColorId)
                .HasDatabaseName("IX_ProductVariants_ColorId");

            // ================================================
            // OFFER CONFIGURATION
            // ================================================
            modelBuilder.Entity<Offer>()
                .Property(o => o.AccentColor)
                .HasDefaultValue("#e8365d");

            // ================================================
            // SEED DATA - ADMIN USER
            // ================================================
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    FullName = "Admin User",
                    Email = "admin@brandsstore.com",
                    Password = "Admin@123",
                    Role = "Admin",
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    PasswordResetOtpHash = null,
                    OtpExpiryTime = null,
                    OtpAttemptCount = 0,
                    OtpLockoutEnd = null,
                    PasswordResetToken = null,
                    ResetTokenExpiryTime = null
                }
            );

            // ================================================
            // SEED DATA - CATEGORIES
            // ================================================
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Jewelry", Description = "Elegant jewelry, including necklaces, rings, earrings, and bracelets", IsActive = true },
                new Category { CategoryId = 2, Name = "Accessories", Description = "Premium accessories, bags, watches, and style items", IsActive = true }
            );

            // ================================================
            // SEED DATA - SIZES
            // ================================================
            // Jewelry (Cat 1)
            modelBuilder.Entity<Size>().HasData(
                new Size { SizeId = 1, CategoryId = 1, SizeName = "16 Inch", SizeOrder = 1, IsActive = true },
                new Size { SizeId = 2, CategoryId = 1, SizeName = "18 Inch", SizeOrder = 2, IsActive = true },
                new Size { SizeId = 3, CategoryId = 1, SizeName = "6", SizeOrder = 3, IsActive = true },
                new Size { SizeId = 4, CategoryId = 1, SizeName = "7", SizeOrder = 4, IsActive = true },
                new Size { SizeId = 5, CategoryId = 1, SizeName = "8", SizeOrder = 5, IsActive = true }
            );
            // Accessories (Cat 2)
            modelBuilder.Entity<Size>().HasData(
                new Size { SizeId = 6, CategoryId = 2, SizeName = "One Size", SizeOrder = 1, IsActive = true }
            );

            // ================================================
            // SEED DATA - COLORS
            // ================================================
            // Jewelry (Cat 1)
            modelBuilder.Entity<Color>().HasData(
                new Color { ColorId = 1, CategoryId = 1, ColorName = "Yellow Gold", ColorCode = "#E6C229", IsActive = true },
                new Color { ColorId = 2, CategoryId = 1, ColorName = "Rose Gold", ColorCode = "#B76E79", IsActive = true },
                new Color { ColorId = 3, CategoryId = 1, ColorName = "Sterling Silver", ColorCode = "#C0C0C0", IsActive = true }
            );
            // Accessories (Cat 2)
            modelBuilder.Entity<Color>().HasData(
                new Color { ColorId = 4, CategoryId = 2, ColorName = "Black", ColorCode = "#000000", IsActive = true },
                new Color { ColorId = 5, CategoryId = 2, ColorName = "Gold", ColorCode = "#FFD700", IsActive = true }
            );

            // ================================================
            // SEED DATA - PRODUCTS
            // ================================================
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, Name = "Diamond Stud Earrings", SKU = "EARS001", Description = "Round brilliant cut diamond stud earrings, set in elegant gold.", CategoryId = 1, Price = 45000.00m, StockQuantity = 12, ImageUrl = "https://images.unsplash.com/photo-1635767798638-3e25273a8236?q=80&w=400", IsActive = true, CreatedDate = DateTime.Now },
                new Product { ProductId = 2, Name = "Diamond Stud Earrings", SKU = "EARS002", Description = "Brilliant cut diamond studs with a sparkling outer halo design.", CategoryId = 1, Price = 45000.00m, StockQuantity = 15, ImageUrl = "https://images.unsplash.com/photo-1630019852942-f89202989a59?q=80&w=400", IsActive = true, CreatedDate = DateTime.Now },
                new Product { ProductId = 3, Name = "Diamond Stud Earrings", SKU = "EARS003", Description = "Delicate dangle earrings with circle diamond cluster links.", CategoryId = 1, Price = 45000.00m, StockQuantity = 10, ImageUrl = "https://images.unsplash.com/photo-1617038260897-41a1f14a8ca0?q=80&w=400", IsActive = true, CreatedDate = DateTime.Now },
                new Product { ProductId = 4, Name = "Diamond Stud Earrings", SKU = "EARS004", Description = "Timeless hoop earrings featuring rows of brilliant diamonds.", CategoryId = 1, Price = 45000.00m, StockQuantity = 8, ImageUrl = "https://images.unsplash.com/photo-1602751584552-8ba73aad10e1?q=80&w=400", IsActive = true, CreatedDate = DateTime.Now },
                new Product { ProductId = 5, Name = "Diamond Stud Earrings", SKU = "EARS005", Description = "Thick gold hoop earrings, highly polished and sparkling.", CategoryId = 1, Price = 89000.00m, StockQuantity = 6, ImageUrl = "https://images.unsplash.com/photo-1535632066927-ab7c9ab60908?q=80&w=400", IsActive = true, CreatedDate = DateTime.Now },
                new Product { ProductId = 6, Name = "Diamond Stud Earrings", SKU = "RNG001", Description = "Stunning cushion-cut diamond engagement ring in yellow gold.", CategoryId = 1, Price = 73000.00m, StockQuantity = 14, ImageUrl = "https://images.unsplash.com/photo-1605100804763-247f67b3557e?q=80&w=400", IsActive = true, CreatedDate = DateTime.Now },
                new Product { ProductId = 7, Name = "Diamond Stud Earrings", SKU = "EARS007", Description = "Geometric square dangle diamond earrings in sterling silver.", CategoryId = 1, Price = 28000.00m, StockQuantity = 9, ImageUrl = "https://images.unsplash.com/photo-1617038221804-03f9b2d69970?q=80&w=400", IsActive = true, CreatedDate = DateTime.Now },
                new Product { ProductId = 8, Name = "Eternity Ring", SKU = "RNG002", Description = "A full eternity band set with brilliant pavé diamonds.", CategoryId = 1, Price = 30000.00m, StockQuantity = 11, ImageUrl = "https://images.unsplash.com/photo-1603561591411-07134e71a2a9?q=80&w=400", IsActive = true, CreatedDate = DateTime.Now }
            );

            // ================================================
            // SEED DATA - VARIANTS
            // ================================================
            modelBuilder.Entity<ProductVariant>().HasData(
                new ProductVariant { VariantId = 1, ProductId = 1, SizeId = 1, ColorId = 1, StockQuantity = 5, Price = 45000.00m, SKU = "EARS001-16-YG", IsActive = true, CreatedAt = DateTime.Now },
                new ProductVariant { VariantId = 2, ProductId = 1, SizeId = 1, ColorId = 2, StockQuantity = 5, Price = 45000.00m, SKU = "EARS001-16-RG", IsActive = true, CreatedAt = DateTime.Now },
                new ProductVariant { VariantId = 3, ProductId = 1, SizeId = 2, ColorId = 1, StockQuantity = 5, Price = 45000.00m, SKU = "EARS001-18-YG", IsActive = true, CreatedAt = DateTime.Now },
                new ProductVariant { VariantId = 4, ProductId = 1, SizeId = 2, ColorId = 2, StockQuantity = 5, Price = 45000.00m, SKU = "EARS001-18-RG", IsActive = true, CreatedAt = DateTime.Now }
            );
        }
    }
}