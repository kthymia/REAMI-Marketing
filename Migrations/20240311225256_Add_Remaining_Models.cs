using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace REAMI_Marketing_Sales___Inventory_System.Migrations
{
    /// <inheritdoc />
    public partial class Add_Remaining_Models : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Company_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Company_Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Contact = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Location = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Company_ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Customer_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Customer_Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Customer_Contact = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Customer_Location = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Customer_ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Employee_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    First_Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Last_Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Middle_Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date_of_Birth = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone_Number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Employee_ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Measurements",
                columns: table => new
                {
                    Measurement_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Measurement_Type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurements", x => x.Measurement_ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Project_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Project_Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Project_ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Role_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Role_Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Role_ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Supply_Details",
                columns: table => new
                {
                    Supply_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Product_ID = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Quantity_Supplied = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supply_Details", x => x.Supply_ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Supplies",
                columns: table => new
                {
                    Supply_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Company_ID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplies", x => x.Supply_ID);
                    table.ForeignKey(
                        name: "FK_Supplies_Companies_Company_ID",
                        column: x => x.Company_ID,
                        principalTable: "Companies",
                        principalColumn: "Company_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Order_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Customer_ID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Order_ID);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_Customer_ID",
                        column: x => x.Customer_ID,
                        principalTable: "Customers",
                        principalColumn: "Customer_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Installation_Details",
                columns: table => new
                {
                    Installation_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Employee_ID = table.Column<int>(type: "int", nullable: false),
                    Role_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Installation_Details", x => x.Installation_ID);
                    table.ForeignKey(
                        name: "FK_Installation_Details_Employees_Employee_ID",
                        column: x => x.Employee_ID,
                        principalTable: "Employees",
                        principalColumn: "Employee_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Installation_Details_Role_Role_ID",
                        column: x => x.Role_ID,
                        principalTable: "Role",
                        principalColumn: "Role_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Installation",
                columns: table => new
                {
                    Installation_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Project_ID = table.Column<int>(type: "int", nullable: false),
                    Order_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Installation", x => x.Installation_ID);
                    table.ForeignKey(
                        name: "FK_Installation_Orders_Order_ID",
                        column: x => x.Order_ID,
                        principalTable: "Orders",
                        principalColumn: "Order_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Installation_Projects_Project_ID",
                        column: x => x.Project_ID,
                        principalTable: "Projects",
                        principalColumn: "Project_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Order_Details",
                columns: table => new
                {
                    Order_Details_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Order_ID = table.Column<int>(type: "int", nullable: false),
                    Product_ID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Unit = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Details", x => x.Order_Details_ID);
                    table.ForeignKey(
                        name: "FK_Order_Details_Orders_Order_ID",
                        column: x => x.Order_ID,
                        principalTable: "Orders",
                        principalColumn: "Order_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Details_Products_Product_ID",
                        column: x => x.Product_ID,
                        principalTable: "Products",
                        principalColumn: "Product_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Product_Details",
                columns: table => new
                {
                    Order_Details_ID = table.Column<int>(type: "int", nullable: false),
                    Measurement_ID = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Details", x => new { x.Order_Details_ID, x.Measurement_ID });
                    table.ForeignKey(
                        name: "FK_Product_Details_Measurements_Measurement_ID",
                        column: x => x.Measurement_ID,
                        principalTable: "Measurements",
                        principalColumn: "Measurement_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Details_Order_Details_Order_Details_ID",
                        column: x => x.Order_Details_ID,
                        principalTable: "Order_Details",
                        principalColumn: "Order_Details_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Installation_Order_ID",
                table: "Installation",
                column: "Order_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Installation_Project_ID",
                table: "Installation",
                column: "Project_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Installation_Details_Employee_ID",
                table: "Installation_Details",
                column: "Employee_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Installation_Details_Role_ID",
                table: "Installation_Details",
                column: "Role_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Details_Order_ID",
                table: "Order_Details",
                column: "Order_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Details_Product_ID",
                table: "Order_Details",
                column: "Product_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Customer_ID",
                table: "Orders",
                column: "Customer_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Details_Measurement_ID",
                table: "Product_Details",
                column: "Measurement_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Supplies_Company_ID",
                table: "Supplies",
                column: "Company_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Installation");

            migrationBuilder.DropTable(
                name: "Installation_Details");

            migrationBuilder.DropTable(
                name: "Product_Details");

            migrationBuilder.DropTable(
                name: "Supplies");

            migrationBuilder.DropTable(
                name: "Supply_Details");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Measurements");

            migrationBuilder.DropTable(
                name: "Order_Details");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
