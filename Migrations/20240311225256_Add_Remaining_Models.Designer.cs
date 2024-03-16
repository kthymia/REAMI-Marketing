﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using REAMI_Marketing_Sales___Inventory_System.Data;

#nullable disable

namespace REAMI_Marketing_Sales___Inventory_System.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240311225256_Add_Remaining_Models")]
    partial class Add_Remaining_Models
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("REAMI_Marketing_Sales___Inventory_System.Models.Company", b =>
                {
                    b.Property<int>("Company_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Company_ID"));

                    b.Property<string>("Company_Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Company_ID");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("REAMI_Marketing_Sales___Inventory_System.Models.Customer", b =>
                {
                    b.Property<int>("Customer_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Customer_ID"));

                    b.Property<string>("Customer_Contact")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Customer_Location")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Customer_Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Customer_ID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("REAMI_Marketing_Sales___Inventory_System.Models.Employee", b =>
                {
                    b.Property<int>("Employee_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Employee_ID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Date_of_Birth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("First_Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Last_Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Middle_Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Phone_Number")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Employee_ID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("REAMI_Marketing_Sales___Inventory_System.Models.Installation", b =>
                {
                    b.Property<int>("Installation_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Installation_ID"));

                    b.Property<int>("Order_ID")
                        .HasColumnType("int");

                    b.Property<int>("Project_ID")
                        .HasColumnType("int");

                    b.HasKey("Installation_ID");

                    b.HasIndex("Order_ID");

                    b.HasIndex("Project_ID");

                    b.ToTable("Installation");
                });

            modelBuilder.Entity("REAMI_Marketing_Sales___Inventory_System.Models.Installation_Detail", b =>
                {
                    b.Property<int>("Installation_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Installation_ID"));

                    b.Property<int>("Employee_ID")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<int>("Role_ID")
                        .HasColumnType("int")
                        .HasColumnOrder(2);

                    b.HasKey("Installation_ID");

                    b.HasIndex("Employee_ID");

                    b.HasIndex("Role_ID");

                    b.ToTable("Installation_Details");
                });

            modelBuilder.Entity("REAMI_Marketing_Sales___Inventory_System.Models.Measurement", b =>
                {
                    b.Property<int>("Measurement_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Measurement_ID"));

                    b.Property<string>("Measurement_Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Measurement_ID");

                    b.ToTable("Measurements");
                });

            modelBuilder.Entity("REAMI_Marketing_Sales___Inventory_System.Models.Order", b =>
                {
                    b.Property<int>("Order_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Order_ID"));

                    b.Property<int>("Customer_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Order_ID");

                    b.HasIndex("Customer_ID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("REAMI_Marketing_Sales___Inventory_System.Models.Order_Detail", b =>
                {
                    b.Property<int>("Order_Details_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Order_Details_ID"));

                    b.Property<int>("Order_ID")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("Product_ID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Order_Details_ID");

                    b.HasIndex("Order_ID");

                    b.HasIndex("Product_ID");

                    b.ToTable("Order_Details");
                });

            modelBuilder.Entity("REAMI_Marketing_Sales___Inventory_System.Models.Product", b =>
                {
                    b.Property<int>("Product_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Product_ID"));

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Product_Desc")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Stocks_available")
                        .HasColumnType("int");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Product_ID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("REAMI_Marketing_Sales___Inventory_System.Models.Product_Detail", b =>
                {
                    b.Property<int>("Order_Details_ID")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<int>("Measurement_ID")
                        .HasColumnType("int")
                        .HasColumnOrder(2);

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Order_Details_ID", "Measurement_ID");

                    b.HasIndex("Measurement_ID");

                    b.ToTable("Product_Details");
                });

            modelBuilder.Entity("REAMI_Marketing_Sales___Inventory_System.Models.Project", b =>
                {
                    b.Property<int>("Project_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Project_ID"));

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Project_Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Project_ID");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("REAMI_Marketing_Sales___Inventory_System.Models.Role", b =>
                {
                    b.Property<int>("Role_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Role_ID"));

                    b.Property<string>("Role_Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Role_ID");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("REAMI_Marketing_Sales___Inventory_System.Models.Supply", b =>
                {
                    b.Property<int>("Supply_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Supply_ID"));

                    b.Property<int>("Company_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Supply_ID");

                    b.HasIndex("Company_ID");

                    b.ToTable("Supplies");
                });

            modelBuilder.Entity("REAMI_Marketing_Sales___Inventory_System.Models.Supply_Detail", b =>
                {
                    b.Property<int>("Supply_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Supply_ID"));

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("Product_ID")
                        .HasColumnType("int")
                        .HasColumnOrder(2);

                    b.Property<int>("Quantity_Supplied")
                        .HasColumnType("int");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnOrder(3);

                    b.HasKey("Supply_ID");

                    b.ToTable("Supply_Details");
                });

            modelBuilder.Entity("REAMI_Marketing_Sales___Inventory_System.Models.Installation", b =>
                {
                    b.HasOne("REAMI_Marketing_Sales___Inventory_System.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("Order_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("REAMI_Marketing_Sales___Inventory_System.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("Project_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("REAMI_Marketing_Sales___Inventory_System.Models.Installation_Detail", b =>
                {
                    b.HasOne("REAMI_Marketing_Sales___Inventory_System.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("Employee_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("REAMI_Marketing_Sales___Inventory_System.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("Role_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("REAMI_Marketing_Sales___Inventory_System.Models.Order", b =>
                {
                    b.HasOne("REAMI_Marketing_Sales___Inventory_System.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("Customer_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("REAMI_Marketing_Sales___Inventory_System.Models.Order_Detail", b =>
                {
                    b.HasOne("REAMI_Marketing_Sales___Inventory_System.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("Order_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("REAMI_Marketing_Sales___Inventory_System.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("Product_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("REAMI_Marketing_Sales___Inventory_System.Models.Product_Detail", b =>
                {
                    b.HasOne("REAMI_Marketing_Sales___Inventory_System.Models.Measurement", "Measurement")
                        .WithMany()
                        .HasForeignKey("Measurement_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("REAMI_Marketing_Sales___Inventory_System.Models.Order_Detail", "OrderDetails")
                        .WithMany()
                        .HasForeignKey("Order_Details_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Measurement");

                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("REAMI_Marketing_Sales___Inventory_System.Models.Supply", b =>
                {
                    b.HasOne("REAMI_Marketing_Sales___Inventory_System.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("Company_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });
#pragma warning restore 612, 618
        }
    }
}
