using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventAggAtLarge.Server.Modules
{
    // NHibernate session management in NServiceBus by Andreas Ohlund
    // http://andreasohlund.net/2010/02/03/nhibernate-session-management-in-nservicebus/

    public class LoggingModule : NServiceBus.IMessageModule
    {
        public void HandleBeginMessage()
        {
            Console.WriteLine("HandleBeginMessage ------------------------------------------------");
        }

        public void HandleEndMessage()
        {
            Console.WriteLine("HandleEndMessage --------------------------------------------------");
        }

        public void HandleError()
        {
            Console.WriteLine("HandleError -------------------------------------------------------");
        }
    }
}
