using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BrandsStore.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedsToMockup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 8, 23, 14, 22, 48, 354, DateTimeKind.Local).AddTicks(3235), 45000.00m, "EARS001-16-YG" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 8, 23, 14, 22, 48, 354, DateTimeKind.Local).AddTicks(3239), 45000.00m, "EARS001-16-RG" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 8, 23, 14, 22, 48, 354, DateTimeKind.Local).AddTicks(3242), 45000.00m, "EARS001-18-YG" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 8, 23, 14, 22, 48, 354, DateTimeKind.Local).AddTicks(3245), 45000.00m, "EARS001-18-RG" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "ImageUrl", "Name", "Price", "SKU", "StockQuantity" },
                values: new object[] { new DateTime(2026, 8, 23, 14, 22, 48, 354, DateTimeKind.Local).AddTicks(3180), "Round brilliant cut diamond stud earrings, set in elegant gold.", "https://images.unsplash.com/photo-1635767798638-3e25273a8236?q=80&w=400", "Diamond Stud Earrings", 45000.00m, "EARS001", 12 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "ImageUrl", "Name", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 8, 23, 14, 22, 48, 354, DateTimeKind.Local).AddTicks(3184), "Brilliant cut diamond studs with a sparkling outer halo design.", "https://images.unsplash.com/photo-1630019852942-f89202989a59?q=80&w=400", "Diamond Stud Earrings", 45000.00m, "EARS002" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "ImageUrl", "Name", "Price", "SKU", "StockQuantity" },
                values: new object[] { new DateTime(2026, 8, 23, 14, 22, 48, 354, DateTimeKind.Local).AddTicks(3187), "Delicate dangle earrings with circle diamond cluster links.", "https://images.unsplash.com/photo-1617038260897-41a1f14a8ca0?q=80&w=400", "Diamond Stud Earrings", 45000.00m, "EARS003", 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "CreatedDate", "Description", "ImageUrl", "Name", "Price", "SKU", "StockQuantity" },
                values: new object[] { new DateTime(2026, 8, 23, 14, 22, 48, 354, DateTimeKind.Local).AddTicks(3190), "Timeless hoop earrings featuring rows of brilliant diamonds.", "https://images.unsplash.com/photo-1602751584552-8ba73aad10e1?q=80&w=400", "Diamond Stud Earrings", 45000.00m, "EARS004", 8 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5,
                columns: new[] { "CreatedDate", "Description", "ImageUrl", "Price", "SKU", "StockQuantity" },
                values: new object[] { new DateTime(2026, 8, 23, 14, 22, 48, 354, DateTimeKind.Local).AddTicks(3193), "Thick gold hoop earrings, highly polished and sparkling.", "https://images.unsplash.com/photo-1535632066927-ab7c9ab60908?q=80&w=400", 89000.00m, "EARS005", 6 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6,
                columns: new[] { "CreatedDate", "Description", "ImageUrl", "Name", "Price", "SKU", "StockQuantity" },
                values: new object[] { new DateTime(2026, 8, 23, 14, 22, 48, 354, DateTimeKind.Local).AddTicks(3196), "Stunning cushion-cut diamond engagement ring in yellow gold.", "https://images.unsplash.com/photo-1605100804763-247f67b3557e?q=80&w=400", "Diamond Stud Earrings", 73000.00m, "RNG001", 14 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "CreatedDate", "Description", "ImageUrl", "IsActive", "Name", "Price", "SKU", "StockQuantity" },
                values: new object[,]
                {
                    { 7, 1, new DateTime(2026, 8, 23, 14, 22, 48, 354, DateTimeKind.Local).AddTicks(3198), "Geometric square dangle diamond earrings in sterling silver.", "https://images.unsplash.com/photo-1617038221804-03f9b2d69970?q=80&w=400", true, "Diamond Stud Earrings", 28000.00m, "EARS007", 9 },
                    { 8, 1, new DateTime(2026, 8, 23, 14, 22, 48, 354, DateTimeKind.Local).AddTicks(3201), "A full eternity band set with brilliant pavé diamonds.", "https://images.unsplash.com/photo-1603561591411-07134e71a2a9?q=80&w=400", true, "Eternity Ring", 30000.00m, "RNG002", 11 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 14, 22, 48, 354, DateTimeKind.Local).AddTicks(2709));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 8, 23, 0, 31, 15, 326, DateTimeKind.Local).AddTicks(5593), 28999.00m, "NKCX231-16-YG" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 8, 23, 0, 31, 15, 326, DateTimeKind.Local).AddTicks(5598), 28999.00m, "NKCX231-16-RG" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 8, 23, 0, 31, 15, 326, DateTimeKind.Local).AddTicks(5601), 28999.00m, "NKCX231-18-YG" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "VariantId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 8, 23, 0, 31, 15, 326, DateTimeKind.Local).AddTicks(5604), 28999.00m, "NKCX231-18-RG" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "ImageUrl", "Name", "Price", "SKU", "StockQuantity" },
                values: new object[] { new DateTime(2026, 8, 23, 0, 31, 15, 326, DateTimeKind.Local).AddTicks(5519), "A modern elegant necklace with a stunning celestial design, crafted for special occasions.", "/images/products/celestial_necklace.jpg", "Celestial Necklace", 28999.00m, "NKCX231", 15 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "ImageUrl", "Name", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 8, 23, 0, 31, 15, 326, DateTimeKind.Local).AddTicks(5523), "Elegant hoop earrings, gold plated and perfect for daily wear.", "/images/products/classic_hoops.jpg", "Classic Hoops", 18995.00m, "EARS321" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "ImageUrl", "Name", "Price", "SKU", "StockQuantity" },
                values: new object[] { new DateTime(2026, 8, 23, 0, 31, 15, 326, DateTimeKind.Local).AddTicks(5526), "A timeless eternity ring studded with sparkling gemstones.", "/images/products/eternity_ring.jpg", "Eternity Ring", 28995.00m, "RNG3021", 30 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "CreatedDate", "Description", "ImageUrl", "Name", "Price", "SKU", "StockQuantity" },
                values: new object[] { new DateTime(2026, 8, 23, 0, 31, 15, 326, DateTimeKind.Local).AddTicks(5530), "Intricately designed Kaanu bracelet ring.", "/images/products/kaanu_ring.jpg", "Kaanu Ring", 28995.00m, "BRA2002", 30 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5,
                columns: new[] { "CreatedDate", "Description", "ImageUrl", "Price", "SKU", "StockQuantity" },
                values: new object[] { new DateTime(2026, 8, 23, 0, 31, 15, 326, DateTimeKind.Local).AddTicks(5533), "Classic diamond stud earrings in yellow gold setting.", "/images/products/diamond_studs.jpg", 45000.00m, "EARS401", 12 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6,
                columns: new[] { "CreatedDate", "Description", "ImageUrl", "Name", "Price", "SKU", "StockQuantity" },
                values: new object[] { new DateTime(2026, 8, 23, 0, 31, 15, 326, DateTimeKind.Local).AddTicks(5557), "Timeless eternity ring crafted in beautiful Rose Gold.", "/images/products/eternity_ring_rose.jpg", "Eternity Ring Rose", 28995.00m, "RNG3022", 30 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 23, 0, 31, 15, 326, DateTimeKind.Local).AddTicks(5076));
        }
    }
}
