# Payment Gateway Application

## Overview
This application demonstrates the **Chain of Responsibility** design pattern by implementing a payment processing system. It supports:

1. **Currency Conversion**: Automatically converts payment amounts to USD using a live currency exchange API.
2. **Payment Methods**:
   - Credit Card
   - PayPal
   - Bank Transfer

## Features
- Uses **FreeCurrencyAPI** to fetch real-time exchange rates.
- Implements a secure `.env` file for managing sensitive API keys.
- Demonstrates key software engineering principles including:
  - SOLID principles
  - Asynchronous programming
  - Logging and error handling

## Prerequisites
- **Visual Studio 2022** or later
- **.NET 6.0** or later
- A FreeCurrencyAPI account (to obtain an API key)

## Installation

1. Clone the repository:
   ```bash
   git clone <repository-url>
   cd <repository-folder>
   ```

2. Install dependencies:
   - Run the application to restore NuGet packages.

3. Add an `.env` file:
   - Create a new file in the project root named `.env`.
   - Add your API key:
     ```env
     API_KEY=fca_live_YourApiKeyHere
     ```

4. Add `.env` to `.gitignore` to keep it secure:
   - Open `.gitignore` in the project root.
   - Add the following line:
     ```
     .env
     ```

## Usage

1. Open the solution in Visual Studio.
2. Run the program using `Ctrl+F5`.
3. Sample payments will be processed:
   - Payments will convert amounts to USD if needed.
   - Logging will display the payment flow in the console.

### Example Output
```
[LOG]: Fetching exchange rate for EUR to USD...
[LOG]: Converted amount: 103.85 USD.
[LOG]: CreditCard is processing the payment.
Processing payment via Credit Card.
...
```

## Project Structure

```
PaymentGateway
├── Handlers
│   ├── BankTransfer.cs
│   ├── CreditCard.cs
│   ├── CurrencyConversion.cs
│   ├── PaymentHandler.cs
│   └── PayPal.cs
├── Models
│   └── Payment.cs
├── Utilities
│   ├── CurrencyExchangeService.cs
│   └── Logger.cs
├── Program.cs
├── .gitignore
└── .env (excluded from version control)
```

## Key Concepts Demonstrated

1. **Chain of Responsibility Pattern**:
   - Handlers process payments sequentially.
   - Each handler either processes the payment or delegates to the next.

2. **Asynchronous Programming**:
   - Currency conversion leverages `async/await` for API calls.

3. **Secure API Key Management**:
   - API key stored in `.env` and excluded from GitHub via `.gitignore`.

## Improvements and Future Enhancements
- Add more payment methods.
- Extend logging to include detailed transaction history.
- Support multiple currency conversion endpoints.

## License
MIT License. See `LICENSE` file for details.

## Acknowledgments
- [FreeCurrencyAPI](https://freecurrencyapi.com/) for providing the live exchange rates.

