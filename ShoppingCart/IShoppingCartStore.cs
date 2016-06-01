using System;
using System.Threading.Tasks;

namespace ShoppingCart
{
    public interface IShoppingCartStore
    {
        Task<Models.ShoppingCart> GetAsnyc(Guid userId);

        Task SaveAsync(Models.ShoppingCart shoppingCart);
    }
}