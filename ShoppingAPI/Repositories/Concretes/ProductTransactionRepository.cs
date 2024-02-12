using System;
using ShoppingAPI.Context;
using ShoppingAPI.Core;
using ShoppingAPI.Entities;
using ShoppingAPI.Repositories.Abstract;

namespace ShoppingAPI.Repositories.Concretes;

public class ProductTransactionRepository : BaseRepository<ProductTransaction>, IProductTransactionRepository
{
    public ProductTransactionRepository(ShoppingDbContext context) : base(context)
    {
    }
}

