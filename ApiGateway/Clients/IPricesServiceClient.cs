using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace microservices.sample.Clients
{
    public interface IPricesServiceClient
    {
        Task<IDictionary<Guid, decimal>> GetCurrentAsync(IEnumerable<Guid> productIds);
    }
}