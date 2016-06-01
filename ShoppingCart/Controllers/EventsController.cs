using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace ShoppingCart.Controllers
{
    [RoutePrefix("events")]
    public class EventsController : ApiController
    {
        private IEventStore eventStore;

        public EventsController(IEventStore eventStore)
        {
            this.eventStore = eventStore;
        }

        [HttpGet]
        public async Task<IEnumerable<Domain.Event>> GetEvents([FromUri]long start, [FromUri]long end)
        {
            return await eventStore.GetEvents(start, end);
        }
    }
}
