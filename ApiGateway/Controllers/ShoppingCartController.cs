using microservices.sample.Clients;
using microservices.sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace microservices.sample.Controllers
{
    [RoutePrefix("api/v1/shoppingcart")]
    public class ShoppingCartController : ApiController
    {
        private IPricesServiceClient prices;
        private IShoppingCartServiceClient shoppingCartService;

        public ShoppingCartController(IShoppingCartServiceClient shoppingCartService, IPricesServiceClient prices)
        {
            this.shoppingCartService = shoppingCartService;
            this.prices = prices;
        }

        [HttpGet]
        [Route("{userId:Guid}")]
        public async Task<ShoppingCart> Get(Guid userId)
        {
            var cart = await shoppingCartService.GetAsync(userId);
            await UpdatePricesAsync(cart);

            return cart;
        }

        [HttpPost]
        [Route("{userId:Guid}/items")]
        public async Task<ShoppingCart> AddItemsToCart(Guid userId, IEnumerable<Guid> productIds)
        {
            var cart = await shoppingCartService.AddItemsToCart(userId, productIds);
            await UpdatePricesAsync(cart);

            return cart;
        }

        private async Task UpdatePricesAsync(ShoppingCart cart)
        {
            var productPrices = await prices.GetCurrentAsync(cart.Items.Select(x => x.ProductId));
            foreach (var productPrice in productPrices)
            {
                cart.Items.Single(x => x.ProductId == productPrice.Key).Price = productPrice.Value;
            }
        }
    }
}
