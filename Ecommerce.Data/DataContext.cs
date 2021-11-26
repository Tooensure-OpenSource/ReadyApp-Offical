using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> dbContextOptions) : base(dbContextOptions) { }
        
        public virtual DbSet<User>? Users { get; set; }
        public virtual DbSet<Business>? Businesses { get; set; }
        public DbSet<ProductItem>? ProductItems { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<OrderItem>? OrderItems { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public virtual DbSet<Owner>? Owners { get; set; }
        public DbSet<Employee>? Employees { get; set; }



        /// <summary>
        /// Comment out onConfiguring override when migrations and database updating is no longer needed.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=DESKTOP-EMFSR5P\\TOOENSURE;Initial Catalog=ReadyAppDb;Integrated Security=True");
        //}
    }
}
