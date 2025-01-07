using PaymentGateway.Handlers;
using PaymentGateway.Models;

class Program
{
  static void Main(string[] args)
  {
    // Create Handlers
    var creditCardHandler = new CreditCard();
    var paypalHandler = new Paypal();
    var bankTransferHandler = new BankTransfer();

    // Chain Handlers
    creditCardHandler.SetNext(paypalHandler).SetNext(bankTransferHandler);

    // Sample payments
    var payment1 = new Payment { CardNumber = 1234567899876543321 };
    var payment2 = new Payment { PayPal = true };
    var payment3 = new Payment { BankAccount = 987654321, BankRoutingNum = 123456789 };
    var payment4 = new Payment { BankAccount = 456456456 };

    // Process sample payments
    creditCardHandler.Handle(payment1);
    creditCardHandler.Handle(payment2);
    creditCardHandler.Handle(payment3);
    creditCardHandler.Handle(payment4);
  }
}