using PaymentGateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Handlers
{
  public abstract class PaymentHandler
  {
    protected PaymentHandler? Next { get; private set; }
    public PaymentHandler SetNext(PaymentHandler nextHandler)
    {
      Next = nextHandler;
      return nextHandler;
    }
    public abstract void Handle(Payment payment);
  }
}
