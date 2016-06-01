using System;

namespace microservices.sample.Models
{
    public class ShoppingCartItem
    {
        public Guid ProductId { get; set; }

        public string ProductName { get; set; }

        public int Count { get; set; }
        
        public decimal Price { get; set; }
    }
}