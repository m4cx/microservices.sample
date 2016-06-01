using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Models
{
    public class ShoppingCart
    {
        private IList<ShoppingCartItem> items;

        public ShoppingCart(Guid userId)
        {
            UserId = userId;
            items = new List<ShoppingCartItem>();
        }

        public Guid UserId { get; private set; }

        public IEnumerable<ShoppingCartItem> Items { get { return items.ToArray(); } }

        public void AddItems(IEnumerable<ShoppingCartItem> items, IEventStore eventStore)
        {
            foreach(var item in items)
            {
                this.items.Add(item);
                eventStore.AddEvent(Domain.Event.CreateNew("ItemAdded", UserId, item.ProductId));
            }
        }
    }
}