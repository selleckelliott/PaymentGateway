using PaymentGateway.Models;
using PaymentGateway.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Handlers
{
  public class BankTransfer : PaymentHandler
  {
    public override async Task Handle(Payment payment)
    {
      if (payment.BankAccount.HasValue && payment.BankRoutingNum.HasValue)
      {
        LogHandlerProcessing(nameof(BankTransfer));
        Console.WriteLine("Processing payment via ACH Transfer");
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
