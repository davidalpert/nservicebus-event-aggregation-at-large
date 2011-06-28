using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using NServiceBus.Testing;
using EventAggAtLarge.Messages;
using NServiceBus;
using EventAggAtLarge.Server.Handlers;
using Rhino.Mocks;

namespace EventAggAtLarge.Tests
{
    public class Server_Handler_Facts
    {
        [Fact]
        public void Handling_an_IPaymentReceived_should_publish_and_IOrderCompleted()
        {
            Test.Initialize();

            /* this sample test doesn't compile as the Handler<T> helper requires T : new() 
             * which doesn't play well with constructor injection.  this test might be made
             * to pass if the PaymentReceivedHandler was refactored to use property injection
             * and an IoC container (like StructureMap) configured to inject the IBus as a 
             * property...
             * 
            Test.Handler<EventAggAtLarge.Server.Handlers.PaymentReceivedHandler>()
                .ExpectPublish<IOrderCompleted>(m => m.OrderNumber == "a123" && m.Purchaser == "Test Customer")
                .OnMessage<IPaymentReceived>(m =>
                {
                    m.Payee = "Test Customer";
                    m.OrderNumber = "a123";
                });
             */
        }
    }
}
