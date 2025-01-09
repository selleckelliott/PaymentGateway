using Newtonsoft.Json;
using dotenv.net;

namespace PaymentGateway.Utilities
{
  public class CurrencyExchangeService
  {
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private const string BaseUrl = "https://api.freecurrencyapi.com/v1/latest";
    public CurrencyExchangeService()
    {
      DotEnv.Load();
      _httpClient = new HttpClient();
      _apiKey = Environment.GetEnvironmentVariable("FREE_CURRENCY_API_KEY") ?? throw new InvalidOperationException("API key not found.");
    }
    public async Task<double> GetExchangeRateAsync(string fromCurrency, string toCurrency = "USD")
    {
      var requestUrl = $"{BaseUrl}?apikey={_apiKey}&base_currency={fromCurrency}&currencies={toCurrency}";

      HttpResponseMessage responseMessage = await _httpClient.GetAsync(requestUrl);
      responseMessage.EnsureSuccessStatusCode();

      string responseBody = await responseMessage.Content.ReadAsStringAsync();
      var data = JsonConvert.DeserializeObject<CurrencyResponse>(responseBody);

      if (data.Data.ContainsKey(toCurrency))
      {
        return data.Data[toCurrency];
      }
      throw new KeyNotFoundException($"Exchange rate for {fromCurrency} to {toCurrency} not found.");
    }
  }
  public class CurrencyResponse
  {
    public Dictionary<string, double>? Data { get; set; }
  }
}
