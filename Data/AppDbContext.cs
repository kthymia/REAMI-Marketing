

using REAMI_Marketing_Sales___Inventory_System.Models;
using Microsoft.EntityFrameworkCore;

namespace REAMI_Marketing_Sales___Inventory_System.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
        
                
        
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Company> Companies { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Installation_Detail> Installation_Details { get; set; }

        public DbSet<Measurement> Measurements { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Order_Detail> Order_Details { get; set; }

        public DbSet<Product_Detail> Product_Details { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Supply> Supplies { get; set; }

        public DbSet<Supply_Detail> Supply_Details { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Configure the relationship between Supply_Detail and Product
            modelBuilder.Entity<Supply_Detail>()
                .HasOne(sd => sd.Product)
                .WithMany()
                .HasForeignKey(sd => sd.Product_ID);
            // Installation
            modelBuilder.Entity<Installation>()
                .HasOne(i => i.Project)
                .WithMany()
                .HasForeignKey(i => i.Project_ID);

            modelBuilder.Entity<Installation>()
                .HasOne(i => i.Order)
                .WithMany()
                .HasForeignKey(i => i.Order_ID);

            // Installation Detail

            modelBuilder.Entity<Installation_Detail>()
                    .HasKey(i => i.Installation_ID);

            modelBuilder.Entity<Installation_Detail>()
                .HasOne(i => i.Employee)
                .WithMany()
                .HasForeignKey(i => i.Employee_ID);

            modelBuilder.Entity<Installation_Detail>()
                .HasOne(i => i.Role)
                .WithMany()
                .HasForeignKey(i => i.Role_ID);

            // Order

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany()
                .HasForeignKey(o => o.Customer_ID);

            // Order Detail

            modelBuilder.Entity<Order_Detail>()
               .HasKey(od => od.Order_Details_ID);

            modelBuilder.Entity<Order_Detail>()
                .HasOne(od => od.Order)
                .WithMany()
                .HasForeignKey(od => od.Order_ID);

            modelBuilder.Entity<Order_Detail>()
                .HasOne(od => od.Product)
                .WithMany()
                .HasForeignKey(od => od.Product_ID);


            // Product Detail


            modelBuilder.Entity<Product_Detail>()
              .HasKey(pd => new { pd.Order_Details_ID, pd.Measurement_ID });

            modelBuilder.Entity<Product_Detail>()
                .HasOne(pd => pd.OrderDetails)
                .WithMany()
                .HasForeignKey(pd => pd.Order_Details_ID);

            modelBuilder.Entity<Product_Detail>()
                .HasOne(pd => pd.Measurement)
                .WithMany()
                .HasForeignKey(pd => pd.Measurement_ID);

            // Supply

            modelBuilder.Entity<Supply>()
                .HasOne(s => s.Company)
                .WithMany()
                .HasForeignKey(s => s.Company_ID);

        }
        public DbSet<REAMI_Marketing_Sales___Inventory_System.Models.Installation> Installation { get; set; } = default!;
        public DbSet<REAMI_Marketing_Sales___Inventory_System.Models.Role> Role { get; set; } = default!;








    }
}
