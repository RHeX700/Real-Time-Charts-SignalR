using RestSharp;
using Newtonsoft.Json;

namespace Real_Time_Charts_SignalR.Models;

public class AlphaVintageClient : IAlphaVintageClient
{
    private readonly string api_key = "GRF50A5KS6HYE1FH";
    public string? fromCurrency { get; set; }
    public string? toCurrency { get; set; }


    public async Task<string> Query()
    {
        var client = new RestClient("https://www.alphavantage.co/");
        var request = new RestRequest("query");

        request.AddParameter("function", "CURRENCY_EXCHANGE_RATE");
        request.AddParameter("from_currency", fromCurrency);
        request.AddParameter("to_currency", toCurrency);
        request.AddParameter("apikey", api_key);

        var response = client.Get(request);

        //AlphaVintageExchangeRateResponse? returnValue = JsonConvert
        //    .DeserializeObject<AlphaVintageExchangeRateResponse>(response.Content);

        return response.Content;
    }
}