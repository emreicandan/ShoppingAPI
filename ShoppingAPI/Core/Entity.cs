using System;
namespace ShoppingAPI.Core;

public class Entity
{

}

public class Entity<PKey> : Entity
{
    public PKey Id { get; set; }
}