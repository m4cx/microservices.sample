using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingCart.Clients
{
    /// <summary>
    /// Schnittstelle für den Zugriff auf Produktinformationen
    /// </summary>
    public interface IProdutcsClient
    {
        Task<IEnumerable<ProductModel>> GetProductsInformationAsync(IEnumerable<Guid> productIds);
    }
}