using microservices.sample.Controllers;
using microservices.sample.Models;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace microservices.sample.Clients
{
    public interface IShoppingCartServiceClient
    {
        Task<ShoppingCart> GetAsync(Guid userId);

        Task<ShoppingCart> AddItemsToCart(Guid userId, IEnumerable<Guid> productIds);
    }
}