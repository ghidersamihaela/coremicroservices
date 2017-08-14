using Nancy;

namespace ShoppingCart
{
    public class EventsFeedModule : NancyModule
    {
        public EventsFeedModule(IEventStore eventStore) : base("/events")
        {
            Get("/", _ =>
            {
                long firstEventSequenceNumber, lastEventSequenceNumber;
                if (!long.TryParse(Request.Query.start.Value,
                    out firstEventSequenceNumber))
                    firstEventSequenceNumber = 0;

                if (!long.TryParse(Request.Query.end.Value,
                    out lastEventSequenceNumber))
                    lastEventSequenceNumber = 0;

                return eventStore.GetEvents(firstEventSequenceNumber,
                    lastEventSequenceNumber);
            });
        }
    }
}
