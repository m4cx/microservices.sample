using System;

namespace ShoppingCart.Models
{
    public class ShoppingCartItem
    {
        public Guid ProductId { get; set; }
        
        public string ProductName { get; set; }

        public int Count { get; set; }
    }
}