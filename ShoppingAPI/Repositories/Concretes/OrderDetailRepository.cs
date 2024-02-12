using System;
using ShoppingAPI.Context;
using ShoppingAPI.Core;
using ShoppingAPI.Entities;
using ShoppingAPI.Repositories.Abstract;

namespace ShoppingAPI.Repositories.Concretes
{
    public class OrderDetailRepository : BaseRepository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(ShoppingDbContext context) : base(context)
        {
        }
    }
}

