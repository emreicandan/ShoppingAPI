using ShoppingAPI.Context;
using ShoppingAPI.Core;
using ShoppingAPI.Entities;
using ShoppingAPI.Repositories.Abstract;

namespace ShoppingAPI.Repositories.Concretes
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ShoppingDbContext context) : base(context)
        {
        }
    }
}

