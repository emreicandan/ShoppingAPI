using System;
using System.ComponentModel.DataAnnotations;
using ShoppingAPI.Core;

namespace ShoppingAPI.Entities;

public class Product : Entity<Guid>
{
    public Guid CategoryId { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public virtual Category Category { get; set; }
    public virtual ICollection<ProductTransaction> ProductTransactions { get; set; }
    public Product()
    {
        ProductTransactions = new HashSet<ProductTransaction>();
    }
}

