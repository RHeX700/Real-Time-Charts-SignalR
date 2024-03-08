namespace Real_Time_Charts_SignalR.Models
{
    public interface IAlphaVintageClient
    {
        public string? fromCurrency { get; set; }
        public string? toCurrency { get; set; }
        public Task<string> Query();
    }
}