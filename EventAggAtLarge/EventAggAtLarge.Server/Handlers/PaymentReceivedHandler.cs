using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EventAggAtLarge.Messages;
using NServiceBus;
using log4net;

namespace EventAggAtLarge.Server.Handlers
{
    public class PaymentReceivedHandler : IHandleMessages<IPaymentReceived>
    {
        IBus bus;

        /// <summary>
        /// Initializes a new instance of the PaymentReceivedHandler class.
        /// </summary>
        /// <param name="bus"></param>
        public PaymentReceivedHandler(IBus bus)
        {
            this.bus = bus;
        }

        public void Handle(IPaymentReceived message)
        {
            Console.WriteLine("Payment Received:");
            Console.WriteLine("- {0}", message.OrderNumber);
            Console.WriteLine("- {0}", message.Payee);
            Console.WriteLine("- {0}", message.Amount);
            Console.WriteLine("- {0}", message.CardNumber);
            Console.WriteLine();
            Console.WriteLine("Looking up the order and applying payment...");

            bus.Publish<IPaymentApplied>(m =>
            {
                m.OrderNumber = message.OrderNumber;
                m.Amount = message.Amount;
            });

            bus.Publish<IOrderCompleted>(m =>
            {
                m.OrderNumber = message.OrderNumber;
                m.Purchaser = message.Payee;
            });
        }
    }

    public class PaymentAppliedHandler : IHandleMessages<IPaymentApplied>
    {
        public void Handle(IPaymentApplied message)
        {
            Console.WriteLine();
            Console.WriteLine("Payment applied: {0} against order #{1}", message.Amount, message.OrderNumber);
        }
    }

    public class OrderCompleted : IHandleMessages<IOrderCompleted>
    {
        public void Handle(IOrderCompleted message)
        {
            Console.WriteLine();
            Console.WriteLine("Order #{0} completed for {1}.", message.OrderNumber, message.Purchaser);
        }
    }
}
