using System;
using Microsoft.EntityFrameworkCore;
using ShoppingAPI.Entities;

namespace ShoppingAPI.Context;

	public class ShoppingDbContext : DbContext
	{

    protected IConfiguration _configuration;

    public ShoppingDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configurationString = _configuration.GetValue<string>("ConnectionStrings:Developer");

        optionsBuilder.UseSqlServer(configurationString);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<ProductTransaction> ProductTransactions { get; set; }
} 

