using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentGateway.Models;
using System.Threading.Tasks;
using PaymentGateway.Handlers;

namespace PaymentGateway.Utilities
{
  public class CurrencyConversion : PaymentHandler
  {
    private readonly CurrencyExchangeService _currencyService;
    public CurrencyConversion()
    {
      _currencyService = new CurrencyExchangeService();
    }
    public override async Task Handle(Payment payment)
    {
      if (payment.Currency != "USD")
      {
        Logger.Log($"Fetching exchange rate for {payment.Currency} to USD...");
        try
        {
          double exchangeRate = await _currencyService.GetExchangeRateAsync(payment.Currency);
          payment.Amount *= exchangeRate;
          payment.Currency = "USD";
          Logger.Log($"converted amount: {payment.Amount} USD.");
        }
        catch (Exception ex)
        {
          Logger.Log($"Currency conversion failed: {ex.Message}");
          return;
        }
      }
      if (Next != null)
      {
        await Next.Handle(payment);
      }
      else
      {
        Logger.Log("Payment method not supported.");
      }
    }
  }
}
