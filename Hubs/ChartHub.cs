using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using Real_Time_Charts_SignalR.Models;

namespace Real_Time_Charts_SignalR.Hubs;

public class ChartHub : Hub<IChartClient>
{
    public async Task ValueSender(AlphaVintageExchangeRateResponse ExchangeRateValue)
    {
        await Clients.Others.ValueReceiver(JsonConvert.SerializeObject(ExchangeRateValue));
    }

    public async Task ChangeCurrencyPair(){
        
    }
}