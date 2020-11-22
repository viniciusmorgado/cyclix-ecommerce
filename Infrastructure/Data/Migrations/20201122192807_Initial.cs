using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductBrand");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductType",
                table: "ProductType");

            migrationBuilder.RenameTable(
                name: "ProductType",
                newName: "BaseEntity");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "BaseEntity",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "BaseEntity",
                type: "nvarchar(180)",
                maxLength: 180,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "BaseEntity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "BaseEntity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "BaseEntity",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductBrandId",
                table: "BaseEntity",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductBrand_Name",
                table: "BaseEntity",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductTypeId",
                table: "BaseEntity",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductType_Name",
                table: "BaseEntity",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseEntity",
                table: "BaseEntity",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_ProductBrandId",
                table: "BaseEntity",
                column: "ProductBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_ProductTypeId",
                table: "BaseEntity",
                column: "ProductTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntity_BaseEntity_ProductBrandId",
                table: "BaseEntity",
                column: "ProductBrandId",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntity_BaseEntity_ProductTypeId",
                table: "BaseEntity",
                column: "ProductTypeId",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntity_BaseEntity_ProductBrandId",
                table: "BaseEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntity_BaseEntity_ProductTypeId",
                table: "BaseEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseEntity",
                table: "BaseEntity");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntity_ProductBrandId",
                table: "BaseEntity");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntity_ProductTypeId",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "ProductBrandId",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "ProductBrand_Name",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "ProductTypeId",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "ProductType_Name",
                table: "BaseEntity");

            migrationBuilder.RenameTable(
                name: "BaseEntity",
                newName: "ProductType");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ProductType",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductType",
                table: "ProductType",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ProductBrand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBrand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(180)", maxLength: 180, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductBrandId = table.Column<int>(type: "int", nullable: false),
                    ProductTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductBrand_ProductBrandId",
                        column: x => x.ProductBrandId,
                        principalTable: "ProductBrand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_ProductType_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductBrandId",
                table: "Products",
                column: "ProductBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTypeId",
                table: "Products",
                column: "ProductTypeId");
        }
    }
}
