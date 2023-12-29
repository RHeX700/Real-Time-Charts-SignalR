// {
//     "Realtime Currency Exchange Rate": {
//         "1. From_Currency Code": "USD",
//         "2. From_Currency Name": "United States Dollar",
//         "3. To_Currency Code": "JPY",
//         "4. To_Currency Name": "Japanese Yen",
//         "5. Exchange Rate": "141.38200000",
//         "6. Last Refreshed": "2023-12-29 15:06:01",
//         "7. Time Zone": "UTC",
//         "8. Bid Price": "141.37630000",
//         "9. Ask Price": "141.38900000"
//     }
// }
using System.Text.Json.Serialization;

namespace Real_Time_Charts_SignalR.Models;

public class AlphaVintageExchangeRateResponse
{
    [JsonPropertyName("1. From_Currency Code")]
    public string SourceCurrency { get; set; }
    [JsonPropertyName("3. To_Currency Code")]
    public string DestinationCurrency { get; set; }
    [JsonPropertyName("2. From_Currency Name")]
    public string SourceCurrencyName { get; set; }
    [JsonPropertyName("4. To_Currency Name")]
    public string DestinationCurrencyName { get; set; }
    [JsonPropertyName("5. Exchange Rate")]
    public decimal ExchangeRate { get; set; }
    [JsonPropertyName("6. Last Refreshed")]
    public DateTime LastUpdated { get; set; }
    [JsonPropertyName("7. Time Zone")]
    public string Timezone { get; set; }
    [JsonPropertyName("9. Ask Price")]
    public decimal AskPrice { get; set; }
    [JsonPropertyName("8. Bid Price")]
    public decimal BidPrice { get; set; }
}