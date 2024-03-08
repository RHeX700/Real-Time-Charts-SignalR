using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR.Client;
using Quartz;
using static System.Net.WebRequestMethods;

namespace Real_Time_Charts_SignalR.Models.Jobs
{
    public class QueryAlphaVintageJob : IJob
    {
        private HubConnection connection;
        private readonly IConfiguration configuration;
        public IAlphaVintageClient alphaVintageClient { get; set; }
        public QueryAlphaVintageJob(IAlphaVintageClient alphaVintageClient, IConfiguration configuration)
        {
            var hubUrl = $"{configuration.GetValue<string>("HubUrl")}";
            this.connection = new HubConnectionBuilder().WithUrl(hubUrl).Build();
            this.alphaVintageClient = alphaVintageClient;
            this.alphaVintageClient.fromCurrency = "USD";
            this.alphaVintageClient.toCurrency = "AUD";
            connection.StartAsync().Wait();
            this.configuration = configuration;
        }


        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Attempting Query...");
            var result = alphaVintageClient.Query();
            result.Wait();
            Console.WriteLine(result.Result);
            connection.SendAsync("ValueSender", result.Result).Wait();
            return Task.CompletedTask;
        }
    }
}
