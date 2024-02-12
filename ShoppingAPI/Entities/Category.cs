using System;
using System.ComponentModel.DataAnnotations;
using ShoppingAPI.Core;

namespace ShoppingAPI.Entities;

public class Category : Entity<Guid>
{
    [MaxLength(50)]
    public string Name { get; set; }

    public virtual ICollection<Product> Products { get; set; }
    public Category()
    {
        Products = new HashSet<Product>();
    }
}