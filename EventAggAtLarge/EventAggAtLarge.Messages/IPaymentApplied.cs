using System;
using NServiceBus;

namespace EventAggAtLarge.Messages
{
    public interface IPaymentApplied : IMessage
    {
        string OrderNumber { get; set; }
        decimal Amount { get; set; }
    }
}