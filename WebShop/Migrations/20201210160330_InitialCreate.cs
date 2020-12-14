using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebShop.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Combo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComboName = table.Column<string>(maxLength: 1000, nullable: true),
                    DayStart = table.Column<DateTime>(nullable: false),
                    DayEnd = table.Column<DateTime>(nullable: false),
                    Total = table.Column<int>(nullable: false),
                    Discount = table.Column<string>(maxLength: 1000, nullable: true),
                    DiscountMoney = table.Column<string>(maxLength: 1000, nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 1000, nullable: false),
                    PassWord = table.Column<string>(maxLength: 1000, nullable: false),
                    Email = table.Column<string>(maxLength: 1000, nullable: false),
                    FirstName = table.Column<string>(maxLength: 35, nullable: false),
                    LastName = table.Column<string>(maxLength: 1000, nullable: false),
                    Gender = table.Column<string>(maxLength: 1000, nullable: false),
                    Birthdate = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(maxLength: 1000, nullable: false),
                    Phone = table.Column<string>(maxLength: 10, nullable: false),
                    JoinDate = table.Column<DateTime>(nullable: false),
                    isNew = table.Column<bool>(nullable: false),
                    status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emplopyee",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    PassWord = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Birthdate = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    JoinDate = table.Column<DateTime>(nullable: false),
                    Role = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emplopyee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Storage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Id = table.Column<string>(nullable: true),
                    Amount = table.Column<string>(nullable: true),
                    importdate = table.Column<DateTime>(nullable: false),
                    exportdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(maxLength: 35, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_Id = table.Column<int>(nullable: false),
                    TotalMoney = table.Column<string>(nullable: true),
                    amount = table.Column<string>(nullable: true),
                    CreateDay = table.Column<DateTime>(nullable: false),
                    Ordernote = table.Column<string>(nullable: true),
                    Postcode = table.Column<string>(nullable: true),
                    CustomerAddress = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoice_Customer_Customer_Id",
                        column: x => x.Customer_Id,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(maxLength: 35, nullable: true),
                    Type_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Type_Type_Id",
                        column: x => x.Type_Id,
                        principalTable: "Type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Invoice_Id = table.Column<int>(nullable: false),
                    Products = table.Column<string>(nullable: true),
                    Combos = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceDetail_Invoice_Invoice_Id",
                        column: x => x.Invoice_Id,
                        principalTable: "Invoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Productname = table.Column<string>(maxLength: 1000, nullable: true),
                    Category_ID = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: true),
                    Price = table.Column<int>(nullable: true),
                    Detail = table.Column<string>(maxLength: 1000, nullable: true),
                    Image = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_Category_ID",
                        column: x => x.Category_ID,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComboProduct",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Combo_Id = table.Column<int>(nullable: false),
                    Product_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComboProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComboProduct_Combo_Combo_Id",
                        column: x => x.Combo_Id,
                        principalTable: "Combo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComboProduct_Product_Product_Id",
                        column: x => x.Product_Id,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_Type_Id",
                table: "Category",
                column: "Type_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ComboProduct_Combo_Id",
                table: "ComboProduct",
                column: "Combo_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ComboProduct_Product_Id",
                table: "ComboProduct",
                column: "Product_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_Customer_Id",
                table: "Invoice",
                column: "Customer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetail_Invoice_Id",
                table: "InvoiceDetail",
                column: "Invoice_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Category_ID",
                table: "Product",
                column: "Category_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComboProduct");

            migrationBuilder.DropTable(
                name: "Emplopyee");

            migrationBuilder.DropTable(
                name: "InvoiceDetail");

            migrationBuilder.DropTable(
                name: "Storage");

            migrationBuilder.DropTable(
                name: "Combo");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Type");
        }
    }
}
