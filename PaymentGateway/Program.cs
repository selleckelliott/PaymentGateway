using PaymentGateway.Handlers;
using PaymentGateway.Models;
using PaymentGateway.Utilities;

class Program
{
  static async Task Main(string[] args)
  {
    // Create Handlers
    var currencyConversionHandler = new CurrencyConversion();
    var creditCardHandler = new CreditCard();
    var paypalHandler = new Paypal();
    var bankTransferHandler = new BankTransfer();

    // Chain Handlers
    currencyConversionHandler.SetNext(creditCardHandler)
      .SetNext(paypalHandler)
      .SetNext(bankTransferHandler);

    // Sample payments
    var payment1 = new Payment { CardNumber = 1234567899876543321, Amount = 100, Currency = "EUR" };
    var payment2 = new Payment { PayPal = true, Amount = 200, Currency = "GBP" };
    var payment3 = new Payment { BankAccount = 987654321, BankRoutingNum = 123456789, Amount = 2000, Currency = "INR" };
    var payment4 = new Payment { BankAccount = 456456456 };

    // Process sample payments
    await currencyConversionHandler.Handle(payment1);
    await currencyConversionHandler.Handle(payment2);
    await currencyConversionHandler.Handle(payment3);
    await currencyConversionHandler.Handle(payment4);
  }
}