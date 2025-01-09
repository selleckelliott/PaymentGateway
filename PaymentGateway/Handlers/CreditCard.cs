using PaymentGateway.Models;
using PaymentGateway.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Handlers
{
  public class CreditCard : PaymentHandler
  {
    public override async Task Handle(Payment payment)
    {
      if (payment.CardNumber != null)
      {
        LogHandlerProcessing(nameof(CreditCard));
        Console.WriteLine("Processing payment via Credit Card.");
        await Task.CompletedTask;
      }
      else if (Next != null)
      {
        await Next.Handle(payment);
      }
      else
      {
        Logger.Log("Payment method not supported.");
        await Task.CompletedTask;
      }
    }
  }
}
