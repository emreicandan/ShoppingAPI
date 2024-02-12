using System;
using ShoppingAPI.Context;
using ShoppingAPI.Core;
using ShoppingAPI.Entities;
using ShoppingAPI.Repositories.Abstract;

namespace ShoppingAPI.Repositories.Concretes;

public class AccountTransactionRepository : BaseRepository<AccountTransaction>, IAccountTransacitonRepository
{
    public AccountTransactionRepository(ShoppingDbContext context) : base(context)
    {
    }
}

