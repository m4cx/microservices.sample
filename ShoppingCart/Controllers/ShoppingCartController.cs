using ShoppingCart.Clients;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace ShoppingCart.Controllers
{
    [RoutePrefix("")]
    public class ShoppingCartController : ApiController
    {
        private IProdutcsClient products;
        private IShoppingCartStore store;
        private IEventStore eventStore;

        public ShoppingCartController(IShoppingCartStore store, IProdutcsClient products, IEventStore eventStore)
        {
            this.store = store;
            this.products = products;
            this.eventStore = eventStore;
        }

        [HttpGet]
        [Route("{userId:Guid}")]
        public async Task<Models.ShoppingCart> GetAsync(Guid userId)
        {
            var cart = await store.GetAsnyc(userId);

            // Produktinformationen zuordnen
            var productInformations = await products.GetProductsInformationAsync(cart.Items.Select(x => x.ProductId));
            foreach (var product in productInformations)
            {
                cart.Items.Single(x => x.ProductId == product.Id).ProductName = product.Name;
            }

            return cart;
        }

        [HttpGet]
        [Route("{userId:Guid}/items")]
        public async Task<Models.ShoppingCart> AddItemsAsync(Guid userId, [FromBody]IEnumerable<Guid> productIds)
        {
            var cart = await store.GetAsnyc(userId);

            var items = (await products.GetProductsInformationAsync(productIds))
                .Select(x => new ShoppingCartItem()
                {
                    ProductId = x.Id,
                    ProductName = x.Name,
                    Count = 1
                });

            cart.AddItems(items, eventStore);

            await store.SaveAsync(cart);

            return await GetAsync(userId);
        }
    }
}