using PaymentGateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Handlers
{
  public class Paypal : PaymentHandler
  {
    public override void Handle(Payment payment)
    {
      if (payment.PayPal == true)
      {
        Console.WriteLine("Processing payment via PayPal.");
      }
      else if (payment.PayPal == false)
      {
        Next.Handle(payment);
      }
      else
      {
        Console.WriteLine("Payment method not supported.");
      }
    }
  }
}
