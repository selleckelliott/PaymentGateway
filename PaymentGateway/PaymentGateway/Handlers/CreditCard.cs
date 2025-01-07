using PaymentGateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Handlers
{
  public class CreditCard : PaymentHandler
  {
    public override void Handle(Payment payment)
    {
      if (payment.CardNumber.HasValue)
      {
        Console.WriteLine("Processing payment via Credit Card.");
      }
      else if (Next != null)
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
