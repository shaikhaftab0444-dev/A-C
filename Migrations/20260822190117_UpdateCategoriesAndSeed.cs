using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BrandsStore.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCategoriesAndSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AddColumn<string>(
                name: "SKU",
                table: "Products",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    ColorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ColorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ColorCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.ColorId);
                    table.ForeignKey(
                        name: "FK_Colors_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    OfferId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Subtitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    BadgeText = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    EyebrowText = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    PrimaryButtonText = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    PrimaryButtonUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SecondaryButtonText = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    SecondaryButtonUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    BackgroundImageUrl = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    AccentColor = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: "#e8365d"),
                    Pill1Title = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Pill1Subtitle = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Pill2Title = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Pill2Subtitle = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.OfferId);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    SizeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SizeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SizeOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.SizeId);
                    table.ForeignKey(
                        name: "FK_Sizes_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductVariants",
                columns: table => new
                {
                    VariantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: true),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SKU = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariants", x => x.VariantId);
                    table.ForeignKey(
                        name: "FK_ProductVariants_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "ColorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductVariants_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductVariants_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "SizeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Elegant jewelry, including necklaces, rings, earrings, and bracelets", "Jewelry" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Premium accessories, bags, watches, and style items", "Accessories" });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "ColorId", "CategoryId", "ColorCode", "ColorName", "IsActive" },
                values: new object[,]
                {
                    { 1, 1, "#E6C229", "Yellow Gold", true },
                    { 2, 1, "#B76E79", "Rose Gold", true },
                    { 3, 1, "#C0C0C0", "Sterling Silver", true },
                    { 4, 2, "#000000", "Black", true },
                    { 5, 2, "#FFD700", "Gold", true }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "CreatedDate", "Description", "ImageUrl", "IsActive", "Name", "Price", "SKU", "StockQuantity" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 8, 23, 0, 31, 15, 326, DateTimeKind.Local).AddTicks(5519), "A modern elegant necklace with a stunning celestial design, crafted for special occasions.", "/images/products/celestial_necklace.jpg", true, "Celestial Necklace", 28999.00m, "NKCX231", 15 },
                    { 2, 1, new DateTime(2026, 8, 23, 0, 31, 15, 326, DateTimeKind.Local).AddTicks(5523), "Elegant hoop earrings, gold plated and perfect for daily wear.", "/images/products/classic_hoops.jpg", true, "Classic Hoops", 18995.00m, "EARS321", 15 },
                    { 3, 1, new DateTime(2026, 8, 23, 0, 31, 15, 326, DateTimeKind.Local).AddTicks(5526), "A timeless eternity ring studded with sparkling gemstones.", "/images/products/eternity_ring.jpg", true, "Eternity Ring", 28995.00m, "RNG3021", 30 },
                    { 4, 1, new DateTime(2026, 8, 23, 0, 31, 15, 326, DateTimeKind.Local).AddTicks(5530), "Intricately designed Kaanu bracelet ring.", "/images/products/kaanu_ring.jpg", true, "Kaanu Ring", 28995.00m, "BRA2002", 30 },
                    { 5, 1, new DateTime(2026, 8, 23, 0, 31, 15, 326, DateTimeKind.Local).AddTicks(5533), "Classic diamond stud earrings in yellow gold setting.", "/images/products/diamond_studs.jpg", true, "Diamond Stud Earrings", 45000.00m, "EARS401", 12 },
                    { 6, 1, new DateTime(2026, 8, 23, 0, 31, 15, 326, DateTimeKind.Local).AddTicks(5557), "Timeless eternity ring crafted in beautiful Rose Gold.", "/images/products/eternity_ring_rose.jpg", true, "Eternity Ring Rose", 28995.00m, "RNG3022", 30 }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "SizeId", "CategoryId", "IsActive", "SizeName", "SizeOrder" },
                values: new object[,]
                {
                    { 1, 1, true, "16 Inch", 1 },
                    { 2, 1, true, "18 Inch", 2 },
                    { 3, 1, true, "6", 3 },
                    { 4, 1, true, "7", 4 },
                    { 5, 1, true, "8", 5 },
                    { 6, 2, true, "One Size", 1 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2026, 8, 23, 0, 31, 15, 326, DateTimeKind.Local).AddTicks(5076), "Admin@123" });

            migrationBuilder.InsertData(
                table: "ProductVariants",
                columns: new[] { "VariantId", "ColorId", "CreatedAt", "IsActive", "Price", "ProductId", "SKU", "SizeId", "StockQuantity" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 8, 23, 0, 31, 15, 326, DateTimeKind.Local).AddTicks(5593), true, 28999.00m, 1, "NKCX231-16-YG", 1, 5 },
                    { 2, 2, new DateTime(2026, 8, 23, 0, 31, 15, 326, DateTimeKind.Local).AddTicks(5598), true, 28999.00m, 1, "NKCX231-16-RG", 1, 5 },
                    { 3, 1, new DateTime(2026, 8, 23, 0, 31, 15, 326, DateTimeKind.Local).AddTicks(5601), true, 28999.00m, 1, "NKCX231-18-YG", 2, 5 },
                    { 4, 2, new DateTime(2026, 8, 23, 0, 31, 15, 326, DateTimeKind.Local).AddTicks(5604), true, 28999.00m, 1, "NKCX231-18-RG", 2, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colors_CategoryId",
                table: "Colors",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_ColorId",
                table: "ProductVariants",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_ProductId",
                table: "ProductVariants",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_SizeId",
                table: "ProductVariants",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_CategoryId",
                table: "Sizes",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "ProductVariants");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "SKU",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Electronic devices and gadgets", "Electronics" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Fashion and apparel", "Clothing" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Description", "IsActive", "Name" },
                values: new object[,]
                {
                    { 3, "Books and publications", true, "Books" },
                    { 4, "Home appliances and kitchen items", true, "Home & Kitchen" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2026, 1, 3, 23, 34, 29, 833, DateTimeKind.Local).AddTicks(1540), "bP7YWvLCZQbJT2nKxQF0Dw==:qO9vEYH9nz4W3pJQQlXGzQ==" });
        }
    }
}
