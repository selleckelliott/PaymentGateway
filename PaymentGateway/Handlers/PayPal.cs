﻿using PaymentGateway.Models;
using PaymentGateway.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Handlers
{
  public class Paypal : PaymentHandler
  {
    public override async Task Handle(Payment payment)
    {
      if (payment.PayPal == true)
      {
        LogHandlerProcessing(nameof(Paypal));
        Console.WriteLine("Processing payment via PayPal.");
        await Task.CompletedTask;
      }
      else if (payment.PayPal == false)
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
