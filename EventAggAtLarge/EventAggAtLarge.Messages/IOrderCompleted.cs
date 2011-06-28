using System;
using NServiceBus;

namespace EventAggAtLarge.Messages
{
    public interface IOrderCompleted : IMessage
    {
        string OrderNumber { get; set; }
        string Purchaser { get; set; }
    }
}
