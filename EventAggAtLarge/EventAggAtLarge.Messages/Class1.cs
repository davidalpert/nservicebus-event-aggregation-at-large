using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;

namespace EventAggAtLarge.Messages
{
    public interface IPaymentReceived : IMessage
    {
        string OrderNumber { get; set; }
        decimal Amount { get; set; }
        string Payee { get; set; }
        string CardNumber { get; set; }
    }
}
