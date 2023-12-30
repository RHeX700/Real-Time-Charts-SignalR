using RestSharp;
using Newtonsoft.Json;

namespace Real_Time_Charts_SignalR.Models;

public class AlphaVintageClient
{
    private readonly string api_key = "GRF50A5KS6HYE1FH";
    public string fromCurrency { get; set; }
    public string toCurrency { get; set; }

    public AlphaVintageClient(string fromCurrency, string toCurrency)
    {
        this.fromCurrency = fromCurrency;
        this.toCurrency = toCurrency;
    }

    public async Task<AlphaVintageExchangeRateResponse> Query()
    {
        var client = new RestClient("https://www.alphavantage.co/");
        var request = new RestRequest("query");

        request.AddParameter("function", "CURRENCY_EXCHANGE_RATE");
        request.AddParameter("from_currency", fromCurrency);
        request.AddParameter("to_currency", toCurrency);
        request.AddParameter("apikey", api_key);

        var response = client.Get(request);

        var returnValue = JsonConvert.DeserializeObject<AlphaVintageExchangeRateResponse>(response.Content);

        return returnValue;
    }
}