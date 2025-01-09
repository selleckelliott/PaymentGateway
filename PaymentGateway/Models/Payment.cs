using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Models
{
  public class Payment
  {
    public double? CardNumber { get; set; }
    public double? BankAccount { get; set; }
    public double? BankRoutingNum { get; set; }
    public bool PayPal { get; set; }
    public string Currency { get; set; } = "USD";
    public double? Amount { get; set; }

    public Payment(double? cardNumber = null, double? bankAccount = null, double? bankRoutingNum = null, 
      bool payPal = false, string currency = "", double? amount = null)
    {
      CardNumber = cardNumber;
      BankAccount = bankAccount;
      BankRoutingNum = bankRoutingNum;
      PayPal = payPal;
      Currency = currency;
      Amount = amount;
    }

  }
}
