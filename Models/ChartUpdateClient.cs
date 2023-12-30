using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Real_Time_Charts_SignalR.Hubs;

namespace Real_Time_Charts_SignalR.Models;

public partial class ChartUpdateClient : IChartClient
{
    HubConnection connection;
    public AlphaVintageClient alphaVintageClient { get; set; }
    public ChartUpdateClient(string hubUrl, AlphaVintageClient alphaVintageClient){
        connection = new HubConnectionBuilder().WithUrl(hubUrl).Build();
        this.alphaVintageClient = alphaVintageClient;

        connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0,5) * 1000);
                await connection.StartAsync();
            };
    }

    public Task ValueReceiver(string chartValue)
    {        
        return default;
    }

    public async Task UpdateChart()
    {
        try
        {
            var result = await alphaVintageClient.Query();
            await connection.SendAsync("ValueSender", result);

        }catch{
            Console.WriteLine("An error occured in the Chart Update Client");
        }

    }

    public async Task ChangeCurrencyPair(string FromCurrency, string ToCurrency)
    {
        alphaVintageClient.fromCurrency = FromCurrency;
        alphaVintageClient.toCurrency = ToCurrency;
    }

    public Task CurrencyPairPageUpdate()
    {
        throw new NotImplementedException();
    }
}