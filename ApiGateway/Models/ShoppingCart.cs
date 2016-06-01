using System;
using System.Collections.Generic;

namespace microservices.sample.Models
{
    public class ShoppingCart
    {
        public Guid UserId { get; set; }

        public IEnumerable<ShoppingCartItem> Items { get; set; }
    }
}