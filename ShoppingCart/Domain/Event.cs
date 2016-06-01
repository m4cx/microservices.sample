using System;

namespace ShoppingCart.Domain
{
    public class Event
    {
        private static long sequenceNumber = 1;

        private Guid productId;
        private long sequence;
        private Guid userId;
        private string v;

        public Event(long sequence, string v, Guid userId, Guid productId)
        {
            this.sequence = sequence;
            this.v = v;
            this.userId = userId;
            this.productId = productId;
        }

        internal static Event CreateNew(string v, Guid userId, Guid productId)
        {
            return new Event(GetNextSequence(), v, userId, productId);
        }

        internal static long GetNextSequence()
        {
            return sequenceNumber++;
        }
    }
}