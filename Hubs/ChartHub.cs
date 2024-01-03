using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using Real_Time_Charts_SignalR.Models;

namespace Real_Time_Charts_SignalR.Hubs;

public class ChartHub : Hub<IChartClient>
{


    public async Task ValueSender(string ExchangeRateValue)
    {
        Console.WriteLine(ExchangeRateValue);
        await Clients.Others.ValueReceiver(ExchangeRateValue);
    }

    public async Task ChangeCurrencyPair(){
        
    }
}