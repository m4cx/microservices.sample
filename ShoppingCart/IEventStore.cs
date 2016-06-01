using System.Collections.Generic;
using System.Threading.Tasks;
using ShoppingCart.Domain;

namespace ShoppingCart
{
    public interface IEventStore
    {
        Task AddEvent(Event @event);

        Task<IEnumerable<Event>> GetEvents(long start, long end);
        
    }
}