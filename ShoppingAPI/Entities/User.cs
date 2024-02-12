using System;
using System.ComponentModel.DataAnnotations;
using ShoppingAPI.Core;

namespace ShoppingAPI.Entities;
public class User : Entity<Guid>
{
    [MaxLength(150)]
    public string FirstName { get; set; }
    [MaxLength(150)]
    public string LastName { get; set; }
    public short BirthYear { get; set; }
    [MaxLength(20)]
    public string IdentificationNumber { get; set; }
    [MaxLength(10)]
    public string? CarPlate { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
    public ICollection<AccountTransaction> AccountTransactions { get; set; }
    public User()
    {
        AccountTransactions = new HashSet<AccountTransaction>();
    }
}