using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EventAggAtLarge.Messages;
using NServiceBus;
using log4net;

namespace EventAggAtLarge.Server.Handlers
{
    public class OrderCompleted_Gloat : IHandleMessages<IOrderCompleted>
    {
        public void Handle(IOrderCompleted message)
        {
            //throw new TimeoutException("twitter is temporarily unavilable...");
            Console.WriteLine("Tweet to our competitors: 'hey, @eurobits, we just sold another one!'");
        }
    }
}
