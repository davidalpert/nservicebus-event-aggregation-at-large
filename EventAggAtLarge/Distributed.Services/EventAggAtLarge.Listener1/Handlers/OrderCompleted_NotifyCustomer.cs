using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EventAggAtLarge.Messages;
using NServiceBus;
using log4net;

namespace EventAggAtLarge.Server.Handlers
{
    public class OrderCompleted_NotifyCustomer : IHandleMessages<IOrderCompleted>
    {
        public void Handle(IOrderCompleted message)
        {
            Console.WriteLine("Notifying customer '{1}' that order #{0} was completed.", message.OrderNumber, message.Purchaser);
        }
    }
}
