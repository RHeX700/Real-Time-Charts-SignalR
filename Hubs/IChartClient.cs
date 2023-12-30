namespace Real_Time_Charts_SignalR.Hubs;

public interface IChartClient
{
    Task ValueReceiver(string chartValue);
    Task CurrencyPairPageUpdate();
}