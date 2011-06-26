using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NServiceBus;
using EventAggAtLarge.Messages;

namespace EventAggAtLarge.WebClient.Controllers
{
    public class PayForm
    {
        public string OrderNumber { get; set; }
        public decimal Amount { get; set; }
        public string Payee { get; set; }
        public string CardNumber { get; set; }
    }

    public class CheckoutController : Controller
    {
        IBus bus;

        /// <summary>
        /// Initializes a new instance of the CheckoutController class.
        /// </summary>
        /// <param name="bus"></param>
        public CheckoutController(IBus bus)
        {
            this.bus = bus;
        }

        //
        // GET: /Checkout/
        public ActionResult ThankYou()
        {
            // try to get the payment information if present
            PayForm form = Session["payForm"] as PayForm;

            if (form == null)
                return View("oops");

            return View(form);
        }

        [HttpGet]
        public ActionResult Pay()
        {
            var defaultFormValues = new PayForm
            {
                OrderNumber = "a223123",
                Payee = "David Alpert",
                Amount = 12.95m,
                CardNumber = "1123123312331234"
            };

            return View(defaultFormValues);
        }

        [HttpPost]
        public ActionResult Pay(PayForm form)
        {
            bus.Send<IPaymentReceived>(m =>
            {
                m.OrderNumber = form.OrderNumber;
                m.Payee = form.Payee;
                m.Amount = form.Amount;
                m.CardNumber = form.CardNumber;
            });

            Session["payForm"] = form;

            return RedirectToAction("ThankYou");
        }
    }
}
