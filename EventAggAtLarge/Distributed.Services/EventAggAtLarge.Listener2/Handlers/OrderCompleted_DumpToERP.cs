using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EventAggAtLarge.Messages;
using NServiceBus;
using log4net;

namespace EventAggAtLarge.Server.Handlers
{
    public class OrderCompleted_DumpToERP : IHandleMessages<IOrderCompleted>
    {
        public void Handle(IOrderCompleted message)
        {
            throw new InvalidOperationException("You forgot to configure me!");
            Console.WriteLine("Serializing order #{0} for integration with back-end ERP system...", message.OrderNumber);
        }
    }
}
