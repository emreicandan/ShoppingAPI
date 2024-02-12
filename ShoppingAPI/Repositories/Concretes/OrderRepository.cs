using System;
using ShoppingAPI.Context;
using ShoppingAPI.Core;
using ShoppingAPI.Entities;
using ShoppingAPI.Repositories.Abstract;

namespace ShoppingAPI.Repositories.Concretes
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(ShoppingDbContext context) : base(context)
        {
        }
    }
}

